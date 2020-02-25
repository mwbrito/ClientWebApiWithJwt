using Newtonsoft.Json;

namespace ClientWebApi.Models
{
    public class LoginResponse
    {
        [JsonProperty(PropertyName = "user")] 
        public User user { get; set; }

        [JsonProperty(PropertyName = "token")] 
        public string Token { get; set; }        
    }
}