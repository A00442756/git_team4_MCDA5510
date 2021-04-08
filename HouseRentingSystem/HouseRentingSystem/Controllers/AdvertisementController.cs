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

namespace HouseRentingSystem.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAdvertisementRepository _advertisementRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;
        public AdvertisementController(IAdvertisementRepository advertisementRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _advertisementRepository = advertisementRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Editad(int adid)
        {

            var advertisement = await _advertisementRepository.GetAdvertisementByAdId(adid);
            if (advertisement == null)
            {
                return NotFound();
            }
            return View(advertisement);
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
                int returnAdid = await _advertisementRepository.EditAdvertisement(advertisement);

                return RedirectToAction(nameof(GetAdvertisement), new{Adid= returnAdid });
            }
            return View(advertisement);
        }

        public async Task<ViewResult> GetAllAdvertisements()
        {
            var data = await _advertisementRepository.GetAllAdvertisement();
            return View(data);
        }

        public async Task<ViewResult> GetAdvertisement(int AdId)
        {
            var data = await _advertisementRepository.GetAdvertisementByAdId(AdId);
            return View(data);
        }

        public async Task<ViewResult> managead(int UserId)
        {
            List<AdvertisementModel> modellist = await  _advertisementRepository.GetAdvertisementsByUserId(UserId);
            return View(modellist);
        }

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
