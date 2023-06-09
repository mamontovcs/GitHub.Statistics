﻿using GitHub.Statistics.API.Models.Interfaces;
using GitHub.Statistics.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Octokit;
using System.Text.Json;

namespace GitHub.Statistics.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("[controller]")]
    public class AccountInfoController : Controller
    {
        private readonly IGitHubAccountInfoReceiver _gitHubAccountInfoReceiver;
        private readonly IMemoryCache _memoryCache;

        public AccountInfoController(IGitHubAccountInfoReceiver gitHubAccountInfoReceiver, IMemoryCache memoryCache)
        {
            _gitHubAccountInfoReceiver = gitHubAccountInfoReceiver;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        [Route("test")]
        public async Task<IActionResult> Test([FromHeader(Name = "AccessToken")] string accessToken)
        {
            _memoryCache.Set("AccessToken", accessToken);

            var accountInfo = await _gitHubAccountInfoReceiver.GetGitHubAccountInfo();

            var json = JsonSerializer.Serialize(accountInfo);

            return Ok(json);
        }
    }
}
