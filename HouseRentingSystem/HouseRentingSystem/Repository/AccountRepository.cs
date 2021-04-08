using HouseRentingSystem.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace HouseRentingSystem.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel signUpUserModel)
        {
            var user = new ApplicationUser() 
            { 
                Email= signUpUserModel.Email,
                UserName=signUpUserModel.Email,
                FirstName=signUpUserModel.FirstName,
                LastName=signUpUserModel.LastName
            };
            var result = await _userManager.CreateAsync(user, signUpUserModel.Password);
            return result;
        }
    }
}
