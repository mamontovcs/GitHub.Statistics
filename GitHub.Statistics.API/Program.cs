using AutoMapper;
using GitHub.Statistics.API.MappingProfiles;
using GitHub.Statistics.API.Services;
using GitHub.Statistics.API.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var clientPolicyName = builder.Configuration.GetSection("ClientPolicyName").Value;

AddServices(services, clientPolicyName);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseAuthorization();
app.UseCors(clientPolicyName);

app.MapControllers();

app.Run();

void AddServices(IServiceCollection services, string clientPolicyName)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSignalR();
    services.AddSwaggerGen();
    services.AddMediatR(Assembly.GetExecutingAssembly());
    services.AddScoped<IMemoryCache, MemoryCache>();

    var mapperConfig = new MapperConfiguration(config =>
    {
        config.AddProfile(new GitHubRepositoryInfoProfile());
        config.AddProfile(new GitHubAccountInfoProfile());
    });

    IMapper mapper = mapperConfig.CreateMapper();
    services.AddSingleton(mapper);

    services.AddTransient<IGitHubClientFactory, GitHubClientFactory>();
    services.AddTransient<IGitHubRepositoriesInfoReceiver, GitHubRepositoriesInfoReceiver>();
    services.AddTransient<IGitHubRepositoryService, GitHubRepositoryService>();
    services.AddTransient<IGitHubAccountInfoReceiver, GitHubAccountInfoReceiver>();
    services.AddTransient<IGitHubRepositoryStatisticsReceiver, GitHubRepositoryStatisticsReceiver>();
    services.AddTransient<IGitHubRepositoryStatisticsBuilder, GitHubRepositoryStatisticsBuilder>();

    services.AddCors(options =>
    {
        options.AddPolicy(clientPolicyName, builder => builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
    });
}
