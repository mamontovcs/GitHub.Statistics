using GitHub.Statistics.API.Models.Interfaces;
using GitHub.Statistics.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Octokit;
using System.Text.Json;

namespace GitHub.Statistics.API.Controllers
{
    /// <summary>
    /// Controller, which is responsible for operating with GitHub repositories
    /// </summary>
    [Route("[controller]")]
    public class RepositoriesController : Controller
    {
        private readonly IGitHubRepositoriesService _gitHubRespotiriesService;
        private readonly IMemoryCache _memoryCache;

        public RepositoriesController(IGitHubRepositoriesService gitHubRespotiriesService, IMemoryCache memoryCache)
        {
            _gitHubRespotiriesService = gitHubRespotiriesService;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        [Route("test")]
        public async Task<IActionResult> Test([FromHeader(Name = "AccessToken")] string accessToken)
        {
            //var githubClient = _gitHubClientFactory.CreateGitHubClient(accessToken);

            //var userName = await githubClient.User.Current();

            //var repositories = await githubClient.Repository.GetAllForUser("mamontovcs");
            _memoryCache.Set("AccessToken", accessToken);

            var gitHubRepositoryInfos = await _gitHubRespotiriesService.GetGitHubRepositoriesInfos();

            var json = JsonSerializer.Serialize(gitHubRepositoryInfos);

            return Ok(json);
        }
    }
}
