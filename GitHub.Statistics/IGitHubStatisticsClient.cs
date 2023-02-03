using GitHub.Statistics.Models.Interfaces;

namespace GitHub.Statistics
{
    public interface IGitHubStatisticsClient
    {
        Task<IEnumerable<IGitHubRepositoryInfo>> GetRepositoriesInfo(string userName, string accessToken = "");
    }
}
