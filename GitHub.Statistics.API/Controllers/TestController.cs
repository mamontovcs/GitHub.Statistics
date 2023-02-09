using Microsoft.AspNetCore.Mvc;

namespace GitHub.Statistics.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            var httpclient = new HttpClient();

            var response = await httpclient.GetAsync("http://githubstatisticsauthentication-web-1:445/login");
            var readResponse = await response.Content.ReadAsStringAsync();

            return Ok(readResponse);
        }
    }
}
