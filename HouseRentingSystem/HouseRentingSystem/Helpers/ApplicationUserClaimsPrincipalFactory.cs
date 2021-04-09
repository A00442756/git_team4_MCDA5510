using HouseRentingSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HouseRentingSystem.Helpers
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, 
            IOptions<IdentityOptions> options) 
            : base(userManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim ("UserFirstName",user.FirstName ?? ""));
            identity.AddClaim(new Claim ("UserLastName",user.LastName ?? ""));
            identity.AddClaim(new Claim ("UserId",user.UserId.ToString()));
            return identity;
        }
    }
}
