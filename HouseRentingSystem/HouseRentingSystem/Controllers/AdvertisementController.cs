using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseRentingSystem.Models;
using HouseRentingSystem.Repository;

namespace HouseRentingSystem.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly AdvertisementRepository _advertisementRepository = null;
        public AdvertisementController(AdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }
        public IActionResult Index()
        {
            return View();
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
            var id = await _advertisementRepository.AddNewAdvertisement(model);
            if (id > 0)
            {
                return RedirectToAction(nameof(managead), new {UserId=0});
            }

            return View();
        }
    }
}
