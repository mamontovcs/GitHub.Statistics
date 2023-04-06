using GitHub.Statistics.API.Models;
using GitHub.Statistics.API.Models.Interfaces;
using GitHub.Statistics.API.Services.Interfaces;

namespace GitHub.Statistics.API.Services
{
    internal class GitHubRepositoryStatisticsBuilder : IGitHubRepositoryStatisticsBuilder
    {
        public IGitHubRepositoryStatistics Build(IGitHubRepositoryInfo gitHubRepositoryInfo, int amountOfCommits)
        {
            return new GitHubRepositoryStatistics(gitHubRepositoryInfo, amountOfCommits);
        }
    }
}
