using DeveloperDashboardClient;
using DeveloperDashboardClient.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorBootstrap;
using DeveloperDashboardClient.Services;


//var owner = "djhansilakshmi";
//var token = "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";

//var jhsniToken = "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";


var owner = "rganesanAltimetrik";

IConfiguration configuration = new ConfigurationBuilder()
           .AddUserSecrets<Program>()
           .Build();



string token = configuration["gitToken"];


var builder = WebAssemblyHostBuilder.CreateDefault(args);

var rameshToken = builder.Configuration["gitToken"];



builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<WeatherForecastService>();
builder.Services.AddBlazorBootstrap();

//builder.Services.AddSingleton<IGitClient, GitClient>(service => { return new GitClient(token); });


//builder.Services.AddTransient<IGitClient, GitClient>(service => new GitClient(rameshToken));

//builder.Services.AddTransient<IBranchService, BranchService>();
//builder.Services.AddTransient<IBuildService, BuildService>();
//builder.Services.AddTransient<ICommitService, CommitService>();
//builder.Services.AddTransient<IDeploymentService, DeploymentService>();
//builder.Services.AddTransient<ICommitService, CommitService>();
//builder.Services.AddTransient<IPullService, PullService>();
//builder.Services.AddTransient<IRepoService, RepoService>();


//builder.Services.AddSingleton<IDashboardService, DashboardService>(service =>
//                             new DashboardService(owner,
//                               service.GetRequiredService<IBranchService>(),
//                                service.GetRequiredService<IBuildService>(),
//                               service.GetRequiredService<ICommitService>(),
//                                service.GetRequiredService<IDeploymentService>(),
//                                service.GetRequiredService<ICommitService>(),
//                                service.GetRequiredService<IPullService>(),
//                                service.GetRequiredService<IRepoService>()
//                                    ));


//builder.Services.AddHttpClient<IAlbumDataService, AlbumDataService>
//    (spds => spds.BaseAddress = new Uri(builder.Configuration["api_jsonplaceholder_base_url"]));

builder.Services.AddHttpClient<IDashboardServiceUI, DashboardServiceUI>
    (spds => spds.BaseAddress = new Uri(builder.Configuration["dashboardBaseUrl"]));

await builder.Build().RunAsync().ConfigureAwait(false);


var profiles = configuration.GetSection("profiles").GetChildren();