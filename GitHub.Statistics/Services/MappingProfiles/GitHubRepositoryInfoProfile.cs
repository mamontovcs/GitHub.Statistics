using AutoMapper;
using GitHub.Statistics.Models;
using GitHub.Statistics.Services.Models.Responses.GetAllRepositoriesFromUser;

namespace GitHub.Statistics.Services.MappingProfiles
{
    internal class GitHubRepositoryInfoProfile : Profile
    {
        public GitHubRepositoryInfoProfile()
        {
            CreateMap<Repository, GitHubRepositoryInfo>();
        }
    }
}
