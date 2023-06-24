using DeveloperDashboardAPI.Clients;
using DeveloperDashboardAPI.Services;
using DeveloperDashboardAPI.Services.GitServices;
using DeveloperDashboardClient.Services.GitServices;

var owner = "rganesanAltimetrik";
var rameshToken = "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";  //"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";

// Add services to the container.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddTransient<IBranchService, BranchService>();
builder.Services.AddTransient<IBuildService, BuildService>();
builder.Services.AddTransient<ICommitService, CommitService>();
builder.Services.AddTransient<IDeploymentService, DeploymentService>();
builder.Services.AddTransient<ICommitService, CommitService>();
builder.Services.AddTransient<IPullService, PullService>();
builder.Services.AddTransient<IRepoService, RepoService>();


builder.Services.AddSingleton<IDashboardService, DashboardService>(service =>
                             new DashboardService(owner,
                                service.GetRequiredService<IBranchService>(),
                                service.GetRequiredService<IBuildService>(),
                               //service.GetRequiredService<ICommitService>(),
                                service.GetRequiredService<IDeploymentService>(),
                                service.GetRequiredService<ICommitService>(),
                                service.GetRequiredService<IPullService>(),
                                service.GetRequiredService<IRepoService>()));

//builder.Services.AddHttpClient<IDashboardService, DashboardService>
//    (spds => spds.BaseAddress = new Uri(builder.Configuration["api_jsonplaceholder_base_url"]));

var app = builder.Build();

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