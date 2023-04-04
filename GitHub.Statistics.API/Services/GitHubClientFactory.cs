using GitHub.Statistics.API.Services.Interfaces;
using Octokit;

namespace GitHub.Statistics.API.Services
{
    internal class GitHubClientFactory : IGitHubClientFactory
    {
        public IGitHubClient CreateGitHubClient(string accessToken)
        {
            var gitHubClient = new GitHubClient(new ProductHeaderValue("Statistics"));
            gitHubClient.Credentials = new Credentials(accessToken);

            return gitHubClient;
        }
    }
}
