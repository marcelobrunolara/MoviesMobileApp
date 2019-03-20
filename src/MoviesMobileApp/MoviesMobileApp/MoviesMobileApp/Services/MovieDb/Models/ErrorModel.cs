using Newtonsoft.Json;

namespace MoviesMobileApp.Services.MovieDb.Models
{
    public class ErrorModel
    {
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }
        [JsonProperty("status_message")]
        public string StatusMessage { get; set; }
    }
}
