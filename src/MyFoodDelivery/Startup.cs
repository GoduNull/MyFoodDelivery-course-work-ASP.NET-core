using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyFoodDelivery.Data;
using MyFoodDelivery.Data.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFoodDelivery.Data.Repository;
using MyFoodDelivery.Data.Models;

namespace MyFoodDelivery
{
    public class Startup
    {
        private IConfigurationRoot _confstring;

        [Obsolete]
        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _confstring = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath).AddJsonFile("MyfoodDbsettings.json").Build();

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSession();
            services.AddTransient<IAllProduct, ProductRepository>();
            services.AddTransient<IFastFoodCafe, FastFoodCafeRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddDbContext<MyFoodDbContent>(options => options.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "productFilter", template: "Products/{action}/{fastFoodCafe?}", defaults: new { Controller = "Products", action = "List" });
                });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            if (env.IsProduction())
            {
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapGet("/", async context =>
                    {
                        await context.Response.WriteAsync("Production!");
                    });
                });
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                MyFoodDbContent content = scope.ServiceProvider.GetRequiredService<MyFoodDbContent>();
                //DbObj.Initial(content);
            }
        }
    }
}
