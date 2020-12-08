using FinancialChat.Repository;
using FinancialChat.Service;
using FinancialChat.StockBot;
using FinancialChat.Web.Areas.ClientServerCommunication.Hubs;
using FinancialChat.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinancialChat.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //DB Contexts Section: For demo purposes, Identity Management and Financial Chat Data will be stored in same DB, but accessed with different Context objects
            //Identity Db Context
            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //Financial Chat Db Context
            services.AddDbContext<FinancialChatContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Dependency Injection for Repositories and Services
            services.AddScoped<IFinancialChatMessageRepository, FinancialChatMessageRepository>();
            services.AddTransient<IFinancialChatMessageService, FinancialChatMessageService>();
            services.AddTransient<IStockBot>(s => new StockBot.StockBot(Configuration["StooqBaseUrl"]));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllersWithViews();
            //Add SignalR services to the current project
            services.AddSignalR(options => options.EnableDetailedErrors = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                //Map income requests with "financialchathub" path to the FinancialChatHub Hub class
                endpoints.MapHub<FinancialChatHub>("/financialchathub");
            });
        }
    }
}
