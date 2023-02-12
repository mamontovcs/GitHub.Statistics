using Microsoft.AspNetCore.Mvc;
using System.Web;

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
            var content = await response.Content.ReadAsStringAsync();

            var absoluteUri = response.RequestMessage.RequestUri.ToString().Split('?')[0];

            Console.WriteLine("URL:" + absoluteUri);

            var nameValues = HttpUtility.
                ParseQueryString(response.RequestMessage.RequestUri.ToString().Split('?')[1]);
            Console.WriteLine("Query: " + response.RequestMessage.RequestUri.Query);
            // return_to parse to correct URI: /signin-github-token
            foreach (var item in nameValues.AllKeys)
            {
                Console.WriteLine("Key: " + item.ToString());
            }
            //var key = nameValues.AllKeys[2];
            //Console.WriteLine("Value:" + nameValues[key]);
            //nameValues[key] = "http://localhost:2509/signin-github-token";
            //Console.WriteLine("Value:" + nameValues[key]);

            var url = absoluteUri + "?" + nameValues;

            Console.WriteLine(url);
            return Redirect(url);
        }

        [HttpGet]
        [Route("setToken")]
        public async Task<IActionResult> SetToken([FromQuery(Name = "token")] string token)
        {
            Console.WriteLine(token);
            return Ok(token);
        }
    }
}
