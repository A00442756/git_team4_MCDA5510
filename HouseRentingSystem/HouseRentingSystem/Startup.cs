using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using HouseRentingSystem.Data;
using HouseRentingSystem.Repository;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using HouseRentingSystem.Models;
using HouseRentingSystem.Helpers;
using HouseRentingSystem.Service;

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
            string connectionstring = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<HouseRentingSystemDBContext>(options => options.UseSqlServer(connectionstring));
            //services.AddControllersWithViews().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreditCardValidator>());
            services.AddControllersWithViews().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PostAdValidator>());
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<HouseRentingSystemDBContext>().AddDefaultTokenProviders();
            /*services.AddControllersWithViews();*/
/*            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<HouseRentingSystemDBContext>();*/
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

            });

            services.ConfigureApplicationCookie(config=> { config.LoginPath = "/signin"; });
#if DEBUG   
            //only valid on development environment
            //auto rebuild razorpages when any razor change is saved
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
            //dependency injection connectionstring to dbcontext instead of using hardcode in

            services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
            services.AddScoped<ICreditCardRepository, CreditCardRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IStarRepository, StarRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();
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
            app.UseAuthentication();
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
