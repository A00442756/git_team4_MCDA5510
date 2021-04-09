using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HouseRentingSystem.Data;
using HouseRentingSystem.Models;
using HouseRentingSystem.Repository;
using Microsoft.AspNetCore.Authorization;
using HouseRentingSystem.Service;

namespace HouseRentingSystem.Controllers
{
    [Authorize]
    public class CreditCardController : Controller
    {
        private readonly ICreditCardRepository _creditCardRepository = null;
        private readonly IUserService _userService = null;

        public CreditCardController(ICreditCardRepository creditCardRepository,
            IUserService userService)
        {
            _creditCardRepository = creditCardRepository;
            _userService = userService;
        }

        // GET: CreditCard
        public async Task<IActionResult> Index()
        {
            var userid = _userService.GetUserId();
            return View(await _creditCardRepository.GetCreditCardByUserid(userid));
        }

        // GET: CreditCard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditCardModel = _creditCardRepository.GetCreditCardByCid(id.Value);
            if (creditCardModel == null)
            {
                return NotFound();
            }

            return View(creditCardModel.Result);
        }

        // GET: CreditCard/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CreditCard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cid,Userid,Cardnumber,Cardtype,Expireyear,Expiremonth,CardHolderName")] CreditCardModel creditCardModel)
        {
            if (ModelState.IsValid)
            {
                creditCardModel.Userid = _userService.GetUserId();
                await _creditCardRepository.AddNewCreditCard(creditCardModel);
                return RedirectToAction(nameof(Index));
            }
            return View(creditCardModel);
        }
/*
        // GET: CreditCard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditCardModel = await _context.CreditCardModel.FindAsync(id);
            if (creditCardModel == null)
            {
                return NotFound();
            }
            return View(creditCardModel);
        }*/

/*        // POST: CreditCard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cid,Userid,Cardnumber,Cardtype,Expireyear,Expiremonth")] CreditCardModel creditCardModel)
        {
            if (id != creditCardModel.Cid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(creditCardModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditCardModelExists(creditCardModel.Cid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(creditCardModel);
        }
*/
        // GET: CreditCard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditCardModel = _creditCardRepository.GetCreditCardByCid(id.Value);

            if(!(_userService.GetUserId()== creditCardModel.Result.Userid))
            {
                return RedirectToAction("Index", "Creditcard");
            }
            if (creditCardModel == null)
            {
                return NotFound();
            }

            return View(creditCardModel.Result);
        }

        // POST: CreditCard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _creditCardRepository.DeleteCreditCard(id);
            return RedirectToAction(nameof(Index));
        }

/*        private bool CreditCardModelExists(int id)
        {
            return _context.CreditCardModel.Any(e => e.Cid == id);
        }*/
    }
}
