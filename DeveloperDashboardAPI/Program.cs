using DeveloperDashboardAPI.Client;
using DeveloperDashboardAPI.Clients;
using DeveloperDashboardAPI.DataServices.DeepSourceServices;
using DeveloperDashboardAPI.DataServices.GitServices;
using DeveloperDashboardAPI.Services.DataServices;

var owner = "rganesanAltimetrik";
var rameshToken = "";


// Add services to the container.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

var DeepSourceURL = "https://api.deepsource.io/graphql/";
var DeepSourceToken = "dsp_c650299d7c381c8f3ae179cbc9c44da442cb";
var DeepSourceowner = "rganesanAltimetrik";

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7262/Albums/all")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin(); // add the allowed origins  
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
                                DeepSourceowner,
                                service.GetRequiredService<IBranchService>(),
                                service.GetRequiredService<IBuildService>(),
                                service.GetRequiredService<IDeploymentService>(),
                                service.GetRequiredService<ICommitService>(),
                                service.GetRequiredService<IPullService>(),
                                service.GetRequiredService<IRepoService>(),
                                service.GetRequiredService<ICodeCoverage>()));

//builder.Services.AddHttpClient<IDashboardService, DashboardService>
//    (spds => spds.BaseAddress = new Uri(builder.Configuration["api_jsonplaceholder_base_url"]));

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync().ConfigureAwait(false);