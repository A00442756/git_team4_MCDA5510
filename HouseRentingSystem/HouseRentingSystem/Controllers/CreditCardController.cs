using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HouseRentingSystem.Data;
using HouseRentingSystem.Models;

namespace HouseRentingSystem.Controllers
{
    public class CreditCardController : Controller
    {
        private readonly HouseRentingSystemDBContext _context;

        public CreditCardController(HouseRentingSystemDBContext context)
        {
            _context = context;
        }

        // GET: CreditCard
        public async Task<IActionResult> Index()
        {
            return View(await _context.CreditCardModel.ToListAsync());
        }

        // GET: CreditCard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditCardModel = await _context.CreditCardModel
                .FirstOrDefaultAsync(m => m.Cid == id);
            if (creditCardModel == null)
            {
                return NotFound();
            }

            return View(creditCardModel);
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
        public async Task<IActionResult> Create([Bind("Cid,Userid,CardNumber,CardType,ExpireYear,ExpireMonth")] CreditCardModel creditCardModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(creditCardModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(creditCardModel);
        }

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
        }

        // POST: CreditCard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cid,Userid,CardNumber,CardType,ExpireYear,ExpireMonth")] CreditCardModel creditCardModel)
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

        // GET: CreditCard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditCardModel = await _context.CreditCardModel
                .FirstOrDefaultAsync(m => m.Cid == id);
            if (creditCardModel == null)
            {
                return NotFound();
            }

            return View(creditCardModel);
        }

        // POST: CreditCard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var creditCardModel = await _context.CreditCardModel.FindAsync(id);
            _context.CreditCardModel.Remove(creditCardModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditCardModelExists(int id)
        {
            return _context.CreditCardModel.Any(e => e.Cid == id);
        }
    }
}
