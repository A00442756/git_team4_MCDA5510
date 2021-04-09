namespace HouseRentingSystem.Service
{
    public interface IUserService
    {
        int GetUserId();
        bool IsAuthenticated();
    }
}