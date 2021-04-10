using HouseRentingSystem.Repository;
using HouseRentingSystem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseRentingSystem.Controllers
{
    [Authorize]
    public class StarController : Controller
    {
        private readonly IStarRepository _starRepository=null;
        private readonly IAdvertisementRepository _advertisementRepository = null;
        private readonly IUserService _userService = null;

        public StarController(IStarRepository starRepository, IUserService userService, IAdvertisementRepository advertisementRepository)
        {
            _starRepository = starRepository;
            _userService = userService;
            _advertisementRepository = advertisementRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddStar(int adId)
        {
            await _starRepository.AddStar(_userService.GetUserId(),adId);
            return RedirectToAction("GetAdvertisement", "Advertisement", new { AdId = adId });
        }
        public async Task<IActionResult> RemoveStar(int adId)
        {
            await _starRepository.RemoveStar(_userService.GetUserId(),adId);
            return RedirectToAction("GetAdvertisement", "Advertisement", new { AdId = adId });
        }
        public async Task<ViewResult> GetStarListAdvertisements()
        {
            var data = await _advertisementRepository.GetStarListAdvertisementsByUserId(_userService.GetUserId());
            return View(data);
        }
    }
}
