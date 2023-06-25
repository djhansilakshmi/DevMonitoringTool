using DeveloperDashboard.DataServices;
using DeveloperDashboardClient;
using DeveloperDashboardClient.Data;
using DeveloperDashboardClient.Client;
using DeveloperDashboardClient.DataServices;
using DeveloperDashboardClient.DataServices.GitServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DeveloperDashboardClient.DataServices.DeepSourceServices;
using DeveloperDashboardClient.Dtos;

// Jhansi Git and Deepsource Details 
//var owner = "djhansilakshmi";
//var rameshToken = "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";
//var DeepSourceToken = "dsp_2c11633e3254558e5d43384580274d9d80f7";

var builder = WebAssemblyHostBuilder.CreateDefault(args);
// Ramesh Git and Deepsource Details 
var owner = builder.Configuration["owner"];// "rganesanAltimetrik";
var rameshToken = builder.Configuration["git_Token"]; //"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";
var DeepSourceToken = builder.Configuration["deepsource_token"]; //"dsp_2c11633e3254558e5d43384580274d9d80f7";
var DeepSourceURL = builder.Configuration["deepsource_url"];


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<WeatherForecastService>();

builder.Services.AddTransient<IGitClient, GitClient>(service => new GitClient(rameshToken));
builder.Services.AddTransient<IDeepsourceClient, DeepsourceClient>(service => new DeepsourceClient(DeepSourceURL, DeepSourceToken));
builder.Services.AddTransient<IBranchService, BranchService>();
builder.Services.AddTransient<IBuildService, BuildService>();
builder.Services.AddTransient<ICommitService, CommitService>();
builder.Services.AddTransient<IDeploymentService, DeploymentService>();
builder.Services.AddTransient<ICommitService, CommitService>();
builder.Services.AddTransient<IPullService, PullService>();
builder.Services.AddTransient<IRepoService, RepoService>();
builder.Services.AddTransient<ICodeCoverage, CodeCoverageService>();


builder.Services.AddSingleton<IDashboardService, DashboardService>(service =>
                             new DashboardService(owner,
                               service.GetRequiredService<IBranchService>(),
                                service.GetRequiredService<IBuildService>(),
                               service.GetRequiredService<ICommitService>(),
                                service.GetRequiredService<IDeploymentService>(),
                                service.GetRequiredService<ICommitService>(),
                                service.GetRequiredService<IPullService>(),
                                service.GetRequiredService<IRepoService>(),
                                service.GetRequiredService<ICodeCoverage>()));


builder.Services.AddHttpClient<IAlbumDataService, AlbumDataService>
    (spds => spds.BaseAddress = new Uri(builder.Configuration["api_jsonplaceholder_base_url"]));

await builder.Build().RunAsync().ConfigureAwait(false);