using GitHub.Statistics.API.Models.Interfaces;

namespace GitHub.Statistics.API.Models
{
    internal record GitHubRepositoryInfo(long Id, string Name) : IGitHubRepositoryInfo;
}
