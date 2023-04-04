using AutoMapper;
using GitHub.Statistics.API.Models;
using Octokit;

namespace GitHub.Statistics.API.MappingProfiles
{
    internal class GitHubRepositoryInfoProfile : Profile
    {
        public GitHubRepositoryInfoProfile()
        {
            CreateMap<Repository, GitHubRepositoryInfo>()
                .ForMember(info => info.Id, opt =>
                opt.MapFrom(repository => repository.Id))
                .ForMember(info => info.Name, opt =>
                opt.MapFrom(repository => repository.Name));
        }
    }
}
