using GitHub.Statistics.API.Models.Interfaces;
using GitHub.Statistics.API.Services.Interfaces;

namespace GitHub.Statistics.API.Services
{
    public class GitHubRepositoryService : IGitHubRepositoryService
    {
        private readonly IGitHubRepositoryInfoReceiver _gitHubRepositoryInfoReceiver;
        private readonly IGitHubRepositoriesInfoReceiver _gitHubRepositoriesInfoReceiver;

        public GitHubRepositoryService(IGitHubRepositoryInfoReceiver gitHubRepositoryInfoReceiver, IGitHubRepositoriesInfoReceiver gitHubRepositoriesInfoReceiver)
        {
            _gitHubRepositoryInfoReceiver = gitHubRepositoryInfoReceiver;
            _gitHubRepositoriesInfoReceiver = gitHubRepositoriesInfoReceiver;
        }

        public async Task<IEnumerable<IGitHubRepositoryInfo>> GetGitHubRepositoriesInfos()
        {
            return await _gitHubRepositoriesInfoReceiver.GetGitHubRepositoriesInfos();
        }

        public async Task<IGitHubRepositoryInfo> GetGitHubRepositoryInfo(long repositoryId)
        {
            return await _gitHubRepositoryInfoReceiver.GetGitHubRepositoryInfo(repositoryId);
        }
    }
}
