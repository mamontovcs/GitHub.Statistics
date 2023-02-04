using AutoMapper;
using GitHub.Statistics.Models.Interfaces;
using GitHub.Statistics.Services.Interfaces;
using System.Web;

namespace GitHub.Statistics.Services
{
    internal class GitHubRepositoryInfoService : IGitHubRepositoryInfoService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        public GitHubRepositoryInfoService(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IGitHubRepositoryInfo>> GetAllRepositoriesFromUser(string userName, string accessToken)
        {

            var httpClient = _httpClientFactory.CreateClient("GitHub");

            var query = HttpUtility.ParseQueryString(httpClient.BaseAddress.Query);

            var message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"search/repositories?q=user:{userName}" + query.ToString(), UriKind.Relative)
            };

            string content = string.Empty;

            try
            {
                var response = await httpClient.SendAsync(message);

                content = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();

                //var responseObject = JsonConvert.DeserializeObject<x>(content);

                //var facebookCampaignInfos = _mapper.Map<IEnumerable<FacebookCampaignInfo>>(responseObject.Data);

                //return facebookCampaignInfos;
            }
            catch (HttpRequestException)
            {
                //throw new FacebookHttpRequestException(content);
            }

            return null;
        }
    }
}
