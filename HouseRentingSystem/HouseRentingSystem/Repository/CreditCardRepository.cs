using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseRentingSystem.Data;
using HouseRentingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Repository
{
    public class CreditCardRepository
    {
        private readonly HouseRentingSystemDBContext _context = null;

        public CreditCardRepository(HouseRentingSystemDBContext context)
        {
            _context = context;
        }


        public async Task<List<CreditCardModel>> GetCreditCardByUserid(int userId)
        {
            List<CreditCardModel> creditCardModels = new List<CreditCardModel>();
            var creditCards = await _context.CreditCards.Where(x => x.Userid == userId).ToListAsync();
            if (creditCards != null && creditCards.Count > 0)
            {
                foreach (var creditcard in creditCards)
                {
                    creditCardModels.Add(new CreditCardModel()
                    {
                        Cid = creditcard.Cid,
                        Userid = creditcard.Userid,
                        Cardnumber = creditcard.Cardnumber,
                        Cardtype = creditcard.Cardtype,
                        Expiremonth = creditcard.Expiremonth,
                        Expireyear = creditcard.Expireyear,
                        CardHolderName = creditcard.CardHolderName
                    });
                }

            }
            return creditCardModels;
        }

        public async Task<CreditCardModel> GetCreditCardByCid(int cid)
        {
            return await _context.CreditCards.Where(x => x.Cid == cid)
                .Select(creditcard=>new CreditCardModel()
                {
                    Cid = creditcard.Cid,
                    Userid = creditcard.Userid,
                    Cardnumber = creditcard.Cardnumber,
                    Cardtype = creditcard.Cardtype,
                    Expiremonth = creditcard.Expiremonth,
                    Expireyear = creditcard.Expireyear,
                    CardHolderName = creditcard.CardHolderName

                }).FirstOrDefaultAsync();
         }

        public async Task<int> AddNewCreditCard(CreditCardModel cardModel)
        {
            var newCard = new CreditCards()
            {
                Cid = cardModel.Cid,
                Userid = cardModel.Userid,
                Cardnumber = cardModel.Cardnumber,
                Cardtype = cardModel.Cardtype,
                Expiremonth = cardModel.Expiremonth,
                Expireyear = cardModel.Expireyear,
                CardHolderName = cardModel.CardHolderName
            };
            await _context.CreditCards.AddAsync(newCard);
            await _context.SaveChangesAsync();
            return newCard.Cid;
        }

        public async Task<int> DeleteCreditCard(int cid)
        {
            var delCard = await _context.CreditCards.FindAsync(cid);
            _context.CreditCards.Remove(delCard);
            return await _context.SaveChangesAsync();
        }

    }
}
