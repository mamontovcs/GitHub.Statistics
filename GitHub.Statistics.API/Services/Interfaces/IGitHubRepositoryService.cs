using GitHub.Statistics.API.Models.Interfaces;

namespace GitHub.Statistics.API.Services.Interfaces
{
    public interface IGitHubRepositoryService
    {
        Task<IEnumerable<IGitHubRepositoryInfo>> GetGitHubRepositoriesInfos();

        Task<IGitHubRepositoryStatistics> GetGitHubRepositoryInfo(long repositoryId);
    }
}
