using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseRentingSystem.Models;
using HouseRentingSystem.Repository;

namespace HouseRentingSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accoutnRepository;

        public AccountController(IAccountRepository accoutnRepository)
        {
            _accoutnRepository = accoutnRepository;
        }

        [Route("signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignUpUserModel signUpUserModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accoutnRepository.CreateUserAsync(signUpUserModel);
                if (!result.Succeeded)
                {
                    foreach(var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return View(signUpUserModel);
                }
                ModelState.Clear();
            }
            return View(signUpUserModel);
        }
        [Route("signin")]
        public IActionResult Signin()
        {
            return View();
        }
        [Route("signin")]
        [HttpPost]
        public async Task<IActionResult> Signin(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accoutnRepository.PasswordSignAsync(signInModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("","Invalid credentials");
            }
            return View(signInModel);
        }

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accoutnRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
