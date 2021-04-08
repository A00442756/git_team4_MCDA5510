using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using HouseRentingSystem.Data;
using HouseRentingSystem.Repository;
using Microsoft.AspNetCore.Identity;
using HouseRentingSystem.Models;

namespace HouseRentingSystem
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
            services.AddControllersWithViews();
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<HouseRentingSystemDBContext>();
#if DEBUG   
            //only valid on development environment
            //auto rebuild razorpages when any razor change is saved
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
            //denpendency injection connectionstring to dbcontext instead of using hardcode in
            string connectionstring = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<HouseRentingSystemDBContext>(options => options.UseSqlServer(connectionstring));
            services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
            services.AddScoped<ICreditCardRepository, CreditCardRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
