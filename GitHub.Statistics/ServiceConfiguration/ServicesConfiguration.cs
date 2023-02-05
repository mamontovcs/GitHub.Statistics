using AutoMapper;
using GitHub.Statistics.Services;
using GitHub.Statistics.Services.Interfaces;
using GitHub.Statistics.Services.MappingProfiles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Reflection;

namespace GitHub.Statistics.ServiceConfiguration
{
    /// <summary>
    /// Extension methods for <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServicesConfiguration
    {
        public static void AddGitHubStatisticsClient(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddHttpClient("GitHub", httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://api.github.com/");
                var productValue = new ProductInfoHeaderValue("GitHubStatisticsClient", "1.0");
                var commentValue = new ProductInfoHeaderValue("(+https://github.com/mamontovcs/GitHub.Statistics)");

                httpClient.DefaultRequestHeaders.UserAgent.Add(productValue);
                httpClient.DefaultRequestHeaders.UserAgent.Add(commentValue);
            });

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GitHubRepositoryInfoProfile());
            });

            services.AddTransient<IGitHubRepositoryInfoService, GitHubRepositoryInfoService>();

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSingleton<IGitHubStatisticsClient, GitHubStatisticsClient>();
        }
    }
}
