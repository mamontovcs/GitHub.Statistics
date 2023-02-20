using GitHub.Statistics.API.Models.Interfaces;
using GitHub.Statistics.API.Services.Interfaces;

namespace GitHub.Statistics.API.Services
{
    public class GitHubRepositoriesService : IGitHubRepositoriesService
    {
        private readonly IGitHubRepositoriesInfoReceiver _gitHubRepositoriesInfoReceiver;

        public GitHubRepositoriesService(IGitHubRepositoriesInfoReceiver gitHubRepositoriesInfoReceiver)
        {
            _gitHubRepositoriesInfoReceiver = gitHubRepositoriesInfoReceiver;
        }

        public async Task<IEnumerable<IGitHubRepositoryInfo>> GetGitHubRepositoriesInfos()
        {
            return await _gitHubRepositoriesInfoReceiver.GetGitHubRepositoriesInfos();
        }
    }
}
