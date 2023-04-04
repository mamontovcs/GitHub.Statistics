using GitHub.Statistics.API.Models.Interfaces;

namespace GitHub.Statistics.API.Services.Interfaces
{
    public interface IGitHubRepositoryInfoReceiver
    {
        Task<IGitHubRepositoryInfo> GetGitHubRepositoryInfo(long repositoryId);
    }
}
