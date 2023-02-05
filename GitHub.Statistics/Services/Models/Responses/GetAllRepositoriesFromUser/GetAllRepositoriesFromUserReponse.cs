using Newtonsoft.Json;

namespace GitHub.Statistics.Services.Models.Responses.GetAllRepositoriesFromUser
{
    internal class GetAllRepositoriesFromUserReponse
    {
        [JsonProperty("items")]
        public IEnumerable<Repository> Repositories { get; set; }
    }
}
