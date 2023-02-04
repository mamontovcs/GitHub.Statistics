using GitHub.Statistics.Models.Interfaces;

namespace GitHub.Statistics.Services.Interfaces
{
    internal interface IGitHubRepositoryInfoService
    {
        Task<IEnumerable<IGitHubRepositoryInfo>> GetAllRepositoriesFromUser(string userName, string accessToken);
    }
}
