using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Power.BO;
using Power.Context;
using Power.Context.Data;
using System;

namespace Power
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
            
            var connection = @"Server=(localdb)\mssqllocaldb;Database=PowerDB;Trusted_Connection=True;ConnectRetryCount=0";

            services.AddDbContext<Power.Context.PowerContext>(options =>
                options.UseSqlServer(connection));

            services.AddIdentity<AppUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<PowerContext>()
                
               
        .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => { options.LoginPath = "/LogIn";
                options.AccessDeniedPath = "/Home/Index";
            });

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.AccessDeniedPath = "/AccessDenied";
            //    options.Cookie.Name = "PowerCookie";
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            //    options.LoginPath = "/Login";
            //    // ReturnUrlParameter requires `using Microsoft.AspNetCore.Authentication.Cookies;`
            //    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            //    options.SlidingExpiration = true;
            //});

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //})
            //.AddCookie(options => {
            //    options.LoginPath = "/Login";

            //});

            services.AddTransient<SeedData>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();
            
            SeedData.Run(app.ApplicationServices).Wait();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
