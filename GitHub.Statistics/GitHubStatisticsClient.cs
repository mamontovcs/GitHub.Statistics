using GitHub.Statistics.Models.Interfaces;
using GitHub.Statistics.Services.MediatR.Requests.Queries;
using MediatR;

namespace GitHub.Statistics
{
    internal class GitHubStatisticsClient : IGitHubStatisticsClient
    {
        private readonly IMediator _mediator;

        public GitHubStatisticsClient(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<IGitHubRepositoryInfo>> GetRepositoriesInfo(string userName, string accessToken = "")
        {
            var gitHubRepositoryInfosQuery = GetGitHubRepositoryInfosQuery.Create(userName, accessToken);

            var gitHubRepositoryInfos = await _mediator.Send(gitHubRepositoryInfosQuery);

            return gitHubRepositoryInfos;
        }
    }
}
