using HouseRentingSystem.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace HouseRentingSystem.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel signUpUserModel);
        Task<SignInResult> PasswordSignAsync(SignInModel signInModel);
        Task SignOutAsync();
    }
}