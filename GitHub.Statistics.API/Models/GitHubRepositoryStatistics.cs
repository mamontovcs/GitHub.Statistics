using GitHub.Statistics.API.Models.Interfaces;

namespace GitHub.Statistics.API.Models
{
    internal record GitHubRepositoryStatistics(IGitHubRepositoryInfo GitHubRepositoryInfo,
        int AmountOfCommits) : IGitHubRepositoryStatistics;
}
