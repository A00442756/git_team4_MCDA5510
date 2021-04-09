using System.Threading.Tasks;

namespace HouseRentingSystem.Repository
{
    public interface IStarRepository
    {
        Task<int> AddStar(int userId, int adId);
        Task<int> RemoveStar(int userId, int adId);
        bool IsFavourite(int adid, int userid);
    }
}