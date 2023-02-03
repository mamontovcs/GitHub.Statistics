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
        public IActionResult Get()
        {
            //await _gitHubStatisticsClient.GetRepositoriesInfo("");

            return Ok("OK OK");
        }
    }
}
