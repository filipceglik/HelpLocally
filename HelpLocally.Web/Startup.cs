using FluentValidation.AspNetCore;
using HelpLocally.Infrastructure;
using HelpLocally.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace HelpLocally.Web
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
            services.AddTransient<IdentityService>();
            services.AddTransient<CompanyService>();
            services.AddTransient<OfferService>();

            services
                .AddRazorPages()
                .AddRazorRuntimeCompilation()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            services
                .AddDbContext<HelpLocallyContext>(builder => { builder.UseNpgsql(Configuration.GetConnectionString("HelpLocallyConnectionString")); });

            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, a =>
                {
                    a.LoginPath = "/Identity/Login";
                    a.Cookie.Name = "Identity.Login";
                    a.Cookie.HttpOnly = true;
                    a.Cookie.IsEssential = true;
                    a.ExpireTimeSpan = new TimeSpan(24, 0, 0);
                });

            services.Configure<CookiePolicyOptions>(opt =>
            {
                opt.CheckConsentNeeded = context => true;
                opt.MinimumSameSitePolicy = SameSiteMode.None;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env/*, CompanyService companyService*/)
        {
            //companyService.RegenerateDbAsync().Wait();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
