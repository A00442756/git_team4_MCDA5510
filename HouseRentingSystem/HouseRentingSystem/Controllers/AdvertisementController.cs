using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HouseRentingSystem.Models;
using HouseRentingSystem.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using HouseRentingSystem.Service;

namespace HouseRentingSystem.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAdvertisementRepository _advertisementRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;
        private readonly IUserService _userService=null;

        public AdvertisementController(IAdvertisementRepository advertisementRepository,
            IWebHostEnvironment webHostEnvironment,
            IUserService userService)
        {
            _advertisementRepository = advertisementRepository;
            _webHostEnvironment = webHostEnvironment;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Editad(int adid)
        {

            var advertisement = await _advertisementRepository.GetAdvertisementByAdId(adid);
            
            if (advertisement == null)
            {
                return NotFound();
            }
            else
            {
                if (_userService.GetUserId() == advertisement.Userid)
                {
                    return View(advertisement);
                }
                else
                {
                    return RedirectToAction("managead", "Advertisement");
                }
                    
            }
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editad(int Adid, [Bind("Adid,Userid,Ondisplay,Title,Rental,PostalCode,ContactPhoneNum,Description,Country,Province,City,Streetname,Streetnum,Bedroomsnum,Bathroomsnum,Hydro,Heat,Water,Internet,Parkingnum,Agreementtype,Moveindate,Petfriendly,Size,Furnished,Laundry,Dishwasher,Fridge,Airconditioning,Smokingpermit")] AdvertisementModel advertisement)
        {
            if (Adid != advertisement.Adid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                advertisement.Userid = _userService.GetUserId();
                int returnAdid = await _advertisementRepository.EditAdvertisement(advertisement);

                return RedirectToAction(nameof(GetAdvertisement), new{Adid= returnAdid });
            }
            return View(advertisement);
        }

        public async Task<ViewResult> GetAllAdvertisements()
        {
            var data = await _advertisementRepository.GetAllAdvertisementOndisplay();
            return View(data);
        }

        public async Task<ViewResult> GetAdvertisement(int AdId)
        {
            var data = await _advertisementRepository.GetAdvertisementByAdId(AdId);
            return View(data);
        }

        [Authorize]
        public async Task<IActionResult> managead()
        {
            if (_userService.IsAuthenticated())
            {
                var userid = _userService.GetUserId();
                List<AdvertisementModel> modellist = await _advertisementRepository.GetAdvertisementsByUserId(userid);
                return View(modellist);
            }
            else
            {
                return RedirectToAction("signin", "Account");
            }

        }


        [Authorize]
        public async Task<ViewResult> postad()
        {
            var model = new AdvertisementModel();
            return View(model);
        }

        [HttpPost]
        
        public async Task<IActionResult> postad(AdvertisementModel model)
        {
            if (ModelState.IsValid)
            {
                model.Userid = _userService.GetUserId();
                if (model.GalleryFiles != null)
                {
                    string folder = "advertisement/gallery/";

                    model.Gallery = new List<GalleryModel>();

                    foreach (var file in model.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            URL = await UploadImage(folder, file),
                            
                        };
                        model.Gallery.Add(gallery);
                    }
                }
                var id = await _advertisementRepository.AddNewAdvertisement(model);
                if (id > 0)
                {
                    return RedirectToAction(nameof(managead), new { UserId = 0 });
                }
            }


            return View();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}
