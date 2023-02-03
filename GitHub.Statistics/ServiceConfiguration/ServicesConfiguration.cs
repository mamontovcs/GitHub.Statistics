using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
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
            });

            var mapperConfig = new MapperConfiguration(mc =>
            {
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSingleton<IGitHubStatisticsClient, GitHubStatisticsClient>();
        }

    }
}
