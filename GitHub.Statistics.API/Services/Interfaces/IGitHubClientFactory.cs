using Octokit;

namespace GitHub.Statistics.API.Services.Interfaces
{
    public interface IGitHubClientFactory
    {
        IGitHubClient CreateGitHubClient(string accessToken);
    }
}
