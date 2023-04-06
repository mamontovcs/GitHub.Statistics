using GitHub.Statistics.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace GitHub.Statistics.API.Controllers
{
    /// <summary>
    /// Controller, which is responsible for operating with GitHub accounts
    /// </summary>
    [Route("[controller]")]
    public class AccountInfoController : Controller
    {
        private readonly IGitHubAccountInfoReceiver _gitHubAccountInfoReceiver;
        private readonly IMemoryCache _memoryCache;

        /// <summary>
        /// Creates instance of <see cref="AccountInfoController"/>
        /// </summary>
        /// <param name="gitHubAccountInfoReceiver"></param>
        /// <param name="memoryCache"></param>
        public AccountInfoController(IGitHubAccountInfoReceiver gitHubAccountInfoReceiver, IMemoryCache memoryCache)
        {
            _gitHubAccountInfoReceiver = gitHubAccountInfoReceiver;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromHeader(Name = "AccessToken")] string accessToken)
        {
            _memoryCache.Set("AccessToken", accessToken);

            var accountInfo = await _gitHubAccountInfoReceiver.GetGitHubAccountInfo();

            return Json(accountInfo);
        }
    }
}
