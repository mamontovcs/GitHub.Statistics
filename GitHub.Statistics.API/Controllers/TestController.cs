using Microsoft.AspNetCore.Mvc;

namespace GitHub.Statistics.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly IGitHubStatisticsClient _gitHubStatisticsClient;

        public TestController(IGitHubStatisticsClient gitHubStatisticsClient)
        {
            _gitHubStatisticsClient = gitHubStatisticsClient;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            await _gitHubStatisticsClient.GetRepositoriesInfo("mamontovcs");

            return Ok("OK OK");
        }
    }
}
