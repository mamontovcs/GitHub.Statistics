using GitHub.Statistics.API.Models.Interfaces;

namespace GitHub.Statistics.API.Services.Interfaces
{
    internal interface IGitHubRepositoryStatisticsBuilder
    {
        IGitHubRepositoryStatistics Build(IGitHubRepositoryInfo gitHubRepositoryInfo, int amountOfCommits);
    }
}
