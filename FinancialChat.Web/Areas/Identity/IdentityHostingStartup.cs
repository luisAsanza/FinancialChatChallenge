using FinancialChat.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FinancialChat.Web.Areas.Identity.IdentityHostingStartup))]
namespace FinancialChat.Web.Areas.Identity
{
    /// <summary>
    /// Allow adding configurations for ASP.NET Identity with customized User properties (FirstName and LastName)
    /// </summary>
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {

                //Set Identity
                //For demo purposes, verification of email won't be included. Otherwise a Email sender will be required.
                //Defined FinancialChatIdentityUser as derived class of IdentityUser which allows to add customized properties.
                services.AddIdentity<FinancialChatIdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<IdentityContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();

                //Dependency injection of customized User Claims Principal Factory (which allows to include new properties as claims for authorization in case we need them
                services.AddScoped<IUserClaimsPrincipalFactory<FinancialChatIdentityUser>, FinancialChatIdentityUserClaimsPrincipalFactory>();

            });
        }
    }
}