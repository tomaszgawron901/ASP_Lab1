using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_PROJECT.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ASP_PROJECT
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration["Data:SportStoreProducts:ConnectionString"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute (
                    name: "default",
                    pattern: "{controller=Product}/{action=List}/{id?}");

                endpoints.MapControllerRoute (
                    name: null,
                    pattern: "Product/{category}",
                    defaults: new { controller = "Product", action = "List" });

                endpoints.MapControllerRoute (
                    name: null,
                    pattern: "Admin/{action}",
                    defaults: new { controller = "Admin", action = "Index" });

            });

            SeedData.EnsurePopulated(app);
        }
    }
}
