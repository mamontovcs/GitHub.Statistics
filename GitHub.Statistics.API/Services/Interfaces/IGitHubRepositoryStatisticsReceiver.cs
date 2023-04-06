using GitHub.Statistics.API.Models.Interfaces;

namespace GitHub.Statistics.API.Services.Interfaces
{
    public interface IGitHubRepositoryStatisticsReceiver
    {
        Task<IGitHubRepositoryStatistics> GetGitHubRepositoryStatistics(long repositoryId);
    }
}
