using GitHub.Statistics.API.Models.Interfaces;

namespace GitHub.Statistics.API.Models
{
    public class GitHubAccountInfo : IGitHubAccountInfo
    {
        public string Name { get; set; }

        public string AvatarUrl { get; set; }
    }
}
