using GitHub.Statistics.API.Models.Interfaces;

namespace GitHub.Statistics.API.Models
{
    internal class GitHubRepositoryInfo : IGitHubRepositoryInfo
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
