using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using shoppingstore.Data;
using shoppingstore.Data.Mocks;
using shoppingstore.Data.Repositories;
using shoppingstore.Models;
using shoppingstore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace shoppingstore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        private IConfigurationRoot _configurationRoot;
        public Startup(IWebHostEnvironment WebHostEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder().SetBasePath(WebHostEnvironment.ContentRootPath)
            .AddJsonFile("appsettings.json")
            .Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //server configuration            
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();
            services.AddScoped<ClaimsPrincipal>(s =>s.GetService<IHttpContextAccessor>().HttpContext.User);
            services.AddControllers(config =>
            {
                config.Filters.Add(typeof(GlobalRouting));
            });
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddTransient<ItemRepository, ItemRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
           
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes => 

            { routes.MapRoute(name: "default", template: "{controller = Home}/{action = Index}/{id?}");
              routes.MapRoute(name: "categoryFiliter", template: "Item/{action)/{category?}", defaults: new {Controller = "Item", action ="List" });
            });
            //app.UseMvcWithDefaultRoute();

            DbInitializer.Seed(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            var scope = app.ApplicationServices.CreateScope();
            var service = scope.ServiceProvider.GetService<IUniqueIdService>();
           
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
            });
        }
    }
}
