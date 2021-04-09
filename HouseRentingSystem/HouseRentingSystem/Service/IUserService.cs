namespace HouseRentingSystem.Service
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}