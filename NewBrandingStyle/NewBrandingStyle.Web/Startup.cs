using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using NewBrandingStyle.Web.Databases;
using Microsoft.AspNetCore.Diagnostics;
using NewBrandingStyle.Web.Models.Validation;
using NewBrandingStyle.Web.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using NewBrandingStyle.Web.Filters;

namespace NewBrandingStyle.Web
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
            services.AddControllersWithViews(config =>
            {
                config.Filters.Add<MyCustomFilter>();
            }).AddFluentValidation();

            services.AddTransient<IValidator<ItemModel>, ItemModelValidator>();

            services.AddDbContext<NewBrandingDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("NewBrandingStyle")));

            services.AddTransient<MyCustomFilter>();
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
