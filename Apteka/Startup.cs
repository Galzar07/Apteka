using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apteka.Core;
using Apteka.Core.Mappers;
using Apteka.Database;
using Apteka.Database.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Apteka
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

            services.AddDbContext<AptekaDbContext>(options => 
                options.UseSqlServer("Server=.;Database=Apteka;Trusted_Connection=True;"));

            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IPrescriptionRepository, PresciptionRepository>();
            services.AddTransient<IMedicineRepository, MedicineRepository>();

            services.AddTransient<DtoMapper>();
            services.AddTransient<ViewModelMapper>();
            services.AddTransient<IDoctorMenager, DoctorMenager >();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            serviceProvider.GetService<AptekaDbContext>().Database.Migrate();
        }
    }
}
