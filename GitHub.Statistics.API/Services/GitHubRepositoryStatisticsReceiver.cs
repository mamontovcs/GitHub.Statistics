using AutoMapper;
using GitHub.Statistics.API.Models;
using GitHub.Statistics.API.Models.Interfaces;
using GitHub.Statistics.API.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace GitHub.Statistics.API.Services
{
    internal class GitHubRepositoryStatisticsReceiver : IGitHubRepositoryStatisticsReceiver
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IGitHubClientFactory _gitHubClientFactory;
        private readonly IGitHubRepositoryStatisticsBuilder _gitHubRepositoryStatisticsBuilder;

        public GitHubRepositoryStatisticsReceiver(IMapper mapper, IMemoryCache memoryCache,
            IGitHubClientFactory gitHubClientFactory,
            IGitHubRepositoryStatisticsBuilder gitHubRepositoryStatisticsBuilder)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _gitHubClientFactory = gitHubClientFactory;
            _gitHubRepositoryStatisticsBuilder = gitHubRepositoryStatisticsBuilder;
        }

        public async Task<IGitHubRepositoryStatistics> GetGitHubRepositoryStatistics(long repositoryId)
        {
            var token = _memoryCache.Get<string>("AccessToken");
            var githubClient = _gitHubClientFactory.CreateGitHubClient(token);

            var repository = await githubClient.Repository.Get(repositoryId);

            var commits = await githubClient.Repository.Commit.GetAll(repositoryId);
            var amountOfCommits = commits.Count;

            var repositoryInfo = _mapper.Map<GitHubRepositoryInfo>(repository);

            var githubStatistics = _gitHubRepositoryStatisticsBuilder.Build(repositoryInfo, amountOfCommits);

            return githubStatistics;
        }
    }
}