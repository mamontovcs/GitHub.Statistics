using Newtonsoft.Json;

namespace GitHub.Statistics.Services.Models.Responses.GetAllRepositoriesFromUser
{
    internal class Repository
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
