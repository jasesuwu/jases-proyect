using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AgroBro.Models;
using Microsoft.AspNetCore.Identity;


namespace AgroBro
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
           {
               options.AddPolicy(name: MyAllowSpecificOrigins,
                   builder =>
                   {
                       builder.WithOrigins("http://localhost:4200")
                                               .AllowAnyHeader()
                                               .AllowAnyMethod();
                   });
           });
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddDbContext<AppDbContext>
            (options => options
               .UseMySql(Configuration.GetConnectionString("AppDbContextString"),
                  new MariaDbServerVersion(new Version(8, 0, 34)))
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors()
            );
            services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins); 
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Vet}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
