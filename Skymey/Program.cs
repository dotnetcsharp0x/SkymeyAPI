using Amazon.Runtime;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Options;
using Skymey.Data;
using Skymey.Pages;
using SkymeyLib.Handlers.HTTPHandler;
using SkymeyLib.Interfaces.Users.Login;
using SkymeyLib.Middleware;
using SkymeyLib.Models.Users;
using SkymeyLib.Models.Users.Login;

namespace Skymey
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddTransient<IValidateToken, ValidateTokenInfo>();
            builder.Services.AddTransient<HttpHandler>();
            builder.Services.AddHttpClient("ServerApi")
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration["ServerUrl"] ?? "https://localhost:7107"))
                .AddHttpMessageHandler<HttpHandler>();
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ServerApi"));

            //builder.Services.AddTransient<HttpHandler>();
            //builder.Services.AddTransient<FetchData>();

            //builder.Services.AddHttpClient("main", httpClient =>
            //{
            //    httpClient.BaseAddress = new Uri(builder.Configuration["ServerUrl"] ?? "");
            //})
            //.AddHttpMessageHandler<HttpHandler>();

            //builder.Services.AddScoped<IHttpClientServiceImplementation, HttpClientFactoryService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection(); 
            app.UseMiddleware<JWTMiddleware>();
            

            app.UseStaticFiles();
            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
