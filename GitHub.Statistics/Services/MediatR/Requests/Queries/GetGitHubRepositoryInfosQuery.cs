using GitHub.Statistics.Models;
using MediatR;

namespace GitHub.Statistics.Services.MediatR.Requests.Queries
{
    internal class GetGitHubRepositoryInfosQuery : BaseRequest, IRequest<IEnumerable<GitHubRepositoryInfo>>
    {
        protected GetGitHubRepositoryInfosQuery(string userName, string accessToken) : base(accessToken)
        {
            UserName = userName;
        }

        public string UserName { get; set; }

        public static GetGitHubRepositoryInfosQuery Create(string userName, string accessToken)
        {
            return new GetGitHubRepositoryInfosQuery(userName, accessToken);
        }
    }
}
