using AutoMapper;
using GitHub.Statistics.Models;
using GitHub.Statistics.Models.Interfaces;
using GitHub.Statistics.Services.Interfaces;
using GitHub.Statistics.Services.Models.Responses.GetAllRepositoriesFromUser;
using Newtonsoft.Json;
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

                var responseObject = JsonConvert.DeserializeObject<GetAllRepositoriesFromUserReponse>(content);

                var gitHubRepositoryInfos = _mapper.Map<IEnumerable<GitHubRepositoryInfo>>(responseObject.Repositories);

                return gitHubRepositoryInfos;
            }
            catch (HttpRequestException)
            {
            }
        }
    }
}
