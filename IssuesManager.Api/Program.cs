using IssuesManager.Core.Interfaces;
using IssuesManager.Core.Models;
using IssuesManager.Core.Services;
using IssuesManager.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<GitHubOptions>(
    builder.Configuration.GetSection(GitHubOptions.PLATFORM_NAME));

builder.Services.AddTransient<GitHubService>();
builder.Services.AddSingleton<IPlatformFactory, PlatformFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


var api = app.MapGroup("/api/v1");
api.MapGitEndpoint();
app.Run();

