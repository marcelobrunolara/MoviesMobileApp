using Newtonsoft.Json;

namespace MoviesMobileApp.Services.Models.MovieDb
{
    public class ErrorModel
    {
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
        [JsonProperty("status_message")]
        public string StatusMessage { get; set; }
    }
}
