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
        public async Task<ViewResult> managead()
        {
            return View();
        }

        public async Task<ViewResult> postad()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> postad(AdvertisementModel model)
        {
            int id = await _advertisementRepository.AddNewAdvertisement(model);
            if (id > 0)
            {
                return Redirect(nameof(managead));
            }

            return View();
        }
    }
}
