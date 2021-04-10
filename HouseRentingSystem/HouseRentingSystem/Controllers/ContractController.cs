﻿using HouseRentingSystem.Models;
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
    public class ContractController : Controller
    {
        private readonly IContractRepository _contractRepository = null;
        private readonly ICreditCardRepository _creditCardRepository = null;
        private readonly IUserService _userService = null;

        public ContractController(IContractRepository contractRepository, 
            ICreditCardRepository creditCardRepository,
            IUserService userService)
        {
            _contractRepository = contractRepository;
            _creditCardRepository = creditCardRepository;
            _userService = userService;
        }

        public IActionResult Index()
        {
            List<ContractsModel> contracts = _contractRepository.GetContractsByUserId(_userService.GetUserId()).Result;
            return View(contracts);
        }

        public async Task<IActionResult> Select(int adid)
        {
            var userid = _userService.GetUserId();
            ViewBag.Adid = adid;
            return View(await _creditCardRepository.GetCreditCardByUserid(userid));
        }

        public async Task<IActionResult> Rent(int cid, int adid)
        {
            var tenantid = _userService.GetUserId();
            await _contractRepository.AddContract(adid,cid,tenantid);
            return RedirectToAction(nameof(Index));
        }
    }
}
