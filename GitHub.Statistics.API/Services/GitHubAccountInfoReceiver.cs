using AutoMapper;
using GitHub.Statistics.API.Models;
using GitHub.Statistics.API.Models.Interfaces;
using GitHub.Statistics.API.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace GitHub.Statistics.API.Services
{
    public class GitHubAccountInfoReceiver : IGitHubAccountInfoReceiver
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IGitHubClientFactory _gitHubClientFactory;

        public GitHubAccountInfoReceiver(IMapper mapper, IMemoryCache memoryCache, IGitHubClientFactory gitHubClientFactory)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _gitHubClientFactory = gitHubClientFactory;
        }

        public async Task<IGitHubAccountInfo> GetGitHubAccountInfo()
        {
            var token = _memoryCache.Get<string>("AccessToken");
            var githubClient = _gitHubClientFactory.CreateGitHubClient(token);

            var user = await githubClient.User.Current();

            var githubAccountInfo = _mapper.Map<GitHubAccountInfo>(user);

            return githubAccountInfo;
        }
    }
}
