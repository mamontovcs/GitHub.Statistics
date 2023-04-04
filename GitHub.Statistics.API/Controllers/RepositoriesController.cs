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
    [Route("api/[controller]")]
    public class RepositoriesController : Controller
    {
        private readonly IGitHubRepositoryService _gitHubRespotiriesService;
        private readonly IMemoryCache _memoryCache;

        public RepositoriesController(IGitHubRepositoryService gitHubRespotiriesService, IMemoryCache memoryCache)
        {
            _gitHubRespotiriesService = gitHubRespotiriesService;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> Get([FromHeader(Name = "AccessToken")] string accessToken)
        {
            _memoryCache.Set("AccessToken", accessToken);

            var gitHubRepositoryInfos = await _gitHubRespotiriesService.GetGitHubRepositoriesInfos();

            return Json(gitHubRepositoryInfos);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromHeader(Name = "AccessToken")] string accessToken, [FromQuery(Name = "id")] long repositoryId)
        {
            _memoryCache.Set("AccessToken", accessToken);

            var gitHubRepositoryInfo = await _gitHubRespotiriesService.GetGitHubRepositoryInfo(repositoryId);

            return Json(gitHubRepositoryInfo);
        }
    }
}
