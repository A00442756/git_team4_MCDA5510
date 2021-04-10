namespace HouseRentingSystem.Service
{
    public interface IUserService
    {
        int GetUserId();
        string GetUserName();
        bool IsAuthenticated();
    }
}