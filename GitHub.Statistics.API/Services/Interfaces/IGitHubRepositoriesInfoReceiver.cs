using GitHub.Statistics.API.Models.Interfaces;

namespace GitHub.Statistics.API.Services.Interfaces
{
    public interface IGitHubRepositoriesInfoReceiver
    {
        Task<IEnumerable<IGitHubRepositoryInfo>> GetGitHubRepositoriesInfos();
    }
}
