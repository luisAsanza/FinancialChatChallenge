using System.Security.Claims;
using System.Threading.Tasks;
using FinancialChat.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace FinancialChat.Web.Areas.Identity
{
    public class FinancialChatIdentityUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<FinancialChatIdentityUser, IdentityRole>
    {
        public FinancialChatIdentityUserClaimsPrincipalFactory(UserManager<FinancialChatIdentityUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options)
            : base(userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(FinancialChatIdentityUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("FirstName", user.FirstName));
            identity.AddClaim(new Claim("LastName", user.LastName));

            return identity;
        }
    }
}
