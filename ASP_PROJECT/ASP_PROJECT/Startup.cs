using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_PROJECT.Middleware;
using ASP_PROJECT.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ASP_PROJECT.Hubs;
using Microsoft.AspNetCore.Authorization;

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
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration["Data:SportStoreProducts:ConnectionString"]));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddRazorPages();
            services.AddControllers();
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddSwaggerGen();
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMiddleware<ElapsedTimeMiddleware>();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "api";
            });


            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chatHub");
                endpoints.MapHub<CounterHub>("/counterHub");


                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "Product/{category}",
                    defaults: new
                    {
                        controller = "Product",
                        action = "List"
                    }
                );

                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "Admin/{action}",
                    defaults: new
                    {
                        controller = "Admin",
                        action = "Index"
                    });

                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "",
                    defaults: new
                    {
                        controller = "Product",
                        action = "List"
                    });
                endpoints.MapControllerRoute(name: null, pattern: "{controller}/{action}/{id?}");

            });

            SeedData.EnsurePopulated(app);
        }
    }
}
