namespace GitHub.Statistics.API.Models.Interfaces
{
    public interface IGitHubRepositoryStatistics
    {
        IGitHubRepositoryInfo GitHubRepositoryInfo { get; }

        int AmountOfCommits { get; }
    }
}
