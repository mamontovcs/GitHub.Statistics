using GitHub.Statistics.API.Models.Interfaces;
using GitHub.Statistics.API.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace GitHub.Statistics.API.Services
{
    public class GitHubRepositoriesInfoReceiver : IGitHubRepositoriesInfoReceiver
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IGitHubClientFactory _gitHubClientFactory;

        public GitHubRepositoriesInfoReceiver(IMemoryCache memoryCache, IGitHubClientFactory gitHubClientFactory)
        {
            _memoryCache = memoryCache;
            _gitHubClientFactory = gitHubClientFactory;
        }

        public async Task<IEnumerable<IGitHubRepositoryInfo>> GetGitHubRepositoriesInfos()
        {
            var token = _memoryCache.Get("AccessToken");

            return new List<IGitHubRepositoryInfo>();
        }
    }
}
