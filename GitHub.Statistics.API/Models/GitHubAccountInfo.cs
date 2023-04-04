using GitHub.Statistics.API.Models.Interfaces;

namespace GitHub.Statistics.API.Models
{
    internal record GitHubAccountInfo(string Name, string AvatarUrl, string Bio,
        string Company, string Email, string Location) : IGitHubAccountInfo;

}
