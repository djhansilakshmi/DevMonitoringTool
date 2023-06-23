using DeveloperDashboard.DataServices;
using DeveloperDashboardClient;
using DeveloperDashboardClient.Data;
using DeveloperDashboardClient.Client;
using DeveloperDashboardClient.DataServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Octokit;


//var owner = "djhansilakshmi";
//var token = "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";

//var token = "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";

var owner = "rganesanAltimetrik";
var token = "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";





var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<WeatherForecastService>();

builder.Services.AddSingleton<IGitClient, GitClient>(service => { return new GitClient(token); });

builder.Services.AddSingleton<IDashboardService, DashboardService>(service =>
                             new DashboardService(owner,
                                     service.GetRequiredService<IGitClient>().GetGithubClient()));


builder.Services.AddHttpClient<IAlbumDataService, AlbumDataService>
    (spds => spds.BaseAddress = new Uri(builder.Configuration["api_jsonplaceholder_base_url"]));

await builder.Build().RunAsync().ConfigureAwait(false);



