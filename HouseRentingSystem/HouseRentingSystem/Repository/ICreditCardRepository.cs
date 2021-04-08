using HouseRentingSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseRentingSystem.Repository
{
    public interface ICreditCardRepository
    {
        Task<int> AddNewCreditCard(CreditCardModel cardModel);
        Task<int> DeleteCreditCard(int cid);
        Task<CreditCardModel> GetCreditCardByCid(int cid);
        Task<List<CreditCardModel>> GetCreditCardByUserid(int userId);
    }
}