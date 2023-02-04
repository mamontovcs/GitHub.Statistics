using GitHub.Statistics.Models.Interfaces;
using GitHub.Statistics.Services.Interfaces;
using GitHub.Statistics.Services.MediatR.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHub.Statistics.Services.MediatR.Handlers
{
    internal class GetGitHubRepositoryInfosQueryHandler : IRequestHandler<GetGitHubRepositoryInfosQuery, IEnumerable<IGitHubRepositoryInfo>>
    {
        private readonly IGitHubRepositoryInfoService _gitHubRepositoryInfoService;

        public GetGitHubRepositoryInfosQueryHandler(IGitHubRepositoryInfoService gitHubRepositoryInfoService)
        {
            _gitHubRepositoryInfoService = gitHubRepositoryInfoService;
        }

        public async Task<IEnumerable<IGitHubRepositoryInfo>> Handle(GetGitHubRepositoryInfosQuery request, CancellationToken cancellationToken)
        {
            return await _gitHubRepositoryInfoService.GetAllRepositoriesFromUser(request.UserName, request.AccessToken);
        }
    }
}
