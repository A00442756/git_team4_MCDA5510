using HouseRentingSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HouseRentingSystem.Repository
{
    public interface IAdvertisementRepository
    {
        Task<int> AddNewAdvertisement(AdvertisementModel model);
        Task<int> EditAdvertisement(AdvertisementModel model);
        Task<AdvertisementModel> GetAdvertisementByAdId(int AdId);
        Task<List<AdvertisementModel>> GetAdvertisementsByUserId(int UserID);
        Task<List<AdvertisementModel>> GetAllAdvertisementOndisplay();
    }
}