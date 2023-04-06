using GitHub.Statistics.API.Models.Interfaces;
using GitHub.Statistics.API.Services.Interfaces;

namespace GitHub.Statistics.API.Services
{
    public class GitHubRepositoryService : IGitHubRepositoryService
    {
        private readonly IGitHubRepositoryStatisticsReceiver _gitHubRepositoryStatisticsReceiver;
        private readonly IGitHubRepositoriesInfoReceiver _gitHubRepositoriesInfoReceiver;

        public GitHubRepositoryService(IGitHubRepositoryStatisticsReceiver gitHubRepositoryStatisticsReceiver, 
            IGitHubRepositoriesInfoReceiver gitHubRepositoriesInfoReceiver)
        {
            _gitHubRepositoryStatisticsReceiver = gitHubRepositoryStatisticsReceiver;
            _gitHubRepositoriesInfoReceiver = gitHubRepositoriesInfoReceiver;
        }

        public async Task<IEnumerable<IGitHubRepositoryInfo>> GetGitHubRepositoriesInfos()
        {
            return await _gitHubRepositoriesInfoReceiver.GetGitHubRepositoriesInfos();
        }

        public async Task<IGitHubRepositoryStatistics> GetGitHubRepositoryInfo(long repositoryId)
        {
            return await _gitHubRepositoryStatisticsReceiver.GetGitHubRepositoryStatistics(repositoryId);
        }
    }
}
