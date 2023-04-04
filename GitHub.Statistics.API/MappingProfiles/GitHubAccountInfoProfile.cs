using AutoMapper;
using GitHub.Statistics.API.Models;
using Octokit;

namespace GitHub.Statistics.API.MappingProfiles
{
    public class GitHubAccountInfoProfile: Profile
    {
        public GitHubAccountInfoProfile()
        {
            CreateMap<User, GitHubAccountInfo>()
                .ForMember(info => info.Name, opt =>
                opt.MapFrom(user => user.Name))
                .ForMember(info => info.AvatarUrl, opt =>
                opt.MapFrom(user => user.AvatarUrl));
        }
    }
}
