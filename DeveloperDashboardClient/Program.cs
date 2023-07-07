using DeveloperDashboardClient;
using DeveloperDashboardClient.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorBootstrap;
using DeveloperDashboardClient.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<WeatherForecastService>();
builder.Services.AddBlazorBootstrap();

//builder.Services.AddHttpClient<IAlbumDataService, AlbumDataService>
//    (spds => spds.BaseAddress = new Uri(builder.Configuration["api_jsonplaceholder_base_url"]));

builder.Services.AddHttpClient<IDashboardServiceUI, DashboardServiceUI>
    (spds => spds.BaseAddress = new Uri(builder.Configuration["dashboardServiceUrl"]));

await builder.Build().RunAsync().ConfigureAwait(false);

