using GitHub.Statistics.API.Models.Interfaces;

namespace GitHub.Statistics.API.Services.Interfaces
{
    public interface IGitHubRepositoriesService
    {
        Task<IEnumerable<IGitHubRepositoryInfo>> GetGitHubRepositoriesInfos(); 
    }
}
