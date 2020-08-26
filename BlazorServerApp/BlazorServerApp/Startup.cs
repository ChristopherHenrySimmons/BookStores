using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorServerApp.Data;
using EmbeddedBlazorContent;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using BlazorServerApp.Services;
<<<<<<< HEAD:BlazorServerApp/BlazorServerApp/Startup.cs
<<<<<<< HEAD:BlazorServerApp/BlazorServerApp/Startup.cs
<<<<<<< HEAD:BlazorServerApp/BlazorServerApp/Startup.cs
using BlazorServerApp.Handlers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
=======
>>>>>>> parent of bec9102... Sending JWT and Building a Outgoing Request Middleware:BlazorServerApp/BlazorApp/BlazorApp/Startup.cs
=======
>>>>>>> parent of bec9102... Sending JWT and Building a Outgoing Request Middleware:BlazorServerApp/BlazorApp/BlazorApp/Startup.cs
=======
>>>>>>> parent of bec9102... Sending JWT and Building a Outgoing Request Middleware:BlazorServerApp/BlazorApp/BlazorApp/Startup.cs

namespace BlazorServerApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();

            var appSettingSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingSection);

            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            
            services.AddBlazoredLocalStorage();
            services.AddHttpClient<IUserService, UserService>();

<<<<<<< HEAD:BlazorServerApp/BlazorServerApp/Startup.cs
<<<<<<< HEAD:BlazorServerApp/BlazorServerApp/Startup.cs
<<<<<<< HEAD:BlazorServerApp/BlazorServerApp/Startup.cs
            services.AddHttpClient<IBookStoresService<Author>, BookStoresService<Author>>()
                    .AddHttpMessageHandler<ValidateHeaderHandler>();
            services.AddHttpClient<IBookStoresService<Publisher>, BookStoresService<Publisher>>()
                    .AddHttpMessageHandler<ValidateHeaderHandler>();
=======
            services.AddHttpClient<IBookStoresService<Author>, BookStoresService<Author>>();
            services.AddHttpClient<IBookStoresService<Publisher>, BookStoresService<Publisher>>();
>>>>>>> parent of bec9102... Sending JWT and Building a Outgoing Request Middleware:BlazorServerApp/BlazorApp/BlazorApp/Startup.cs
=======
            services.AddHttpClient<IBookStoresService<Author>, BookStoresService<Author>>();
            services.AddHttpClient<IBookStoresService<Publisher>, BookStoresService<Publisher>>();
>>>>>>> parent of bec9102... Sending JWT and Building a Outgoing Request Middleware:BlazorServerApp/BlazorApp/BlazorApp/Startup.cs
=======
            services.AddHttpClient<IBookStoresService<Author>, BookStoresService<Author>>();
            services.AddHttpClient<IBookStoresService<Publisher>, BookStoresService<Publisher>>();
>>>>>>> parent of bec9102... Sending JWT and Building a Outgoing Request Middleware:BlazorServerApp/BlazorApp/BlazorApp/Startup.cs

            services.AddSingleton<HttpClient>();

            services.AddAuthorization(options => 
            {
                options.AddPolicy("SeniorEmployee", policy => 
                    policy.RequireClaim("IsUserEmployedBefore1990","true"));
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();            
        
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");                
            });
        }
    }
}
