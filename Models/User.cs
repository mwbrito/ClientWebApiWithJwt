using Newtonsoft.Json;

namespace ClientWebApi.Models
{
    public class User
    {
        [JsonProperty(PropertyName = "id")] 
        public int Id { get; set; }

        [JsonProperty(PropertyName = "username")] 
        public string Username { get; set; }

        [JsonProperty(PropertyName = "password")] 
        public string Password { get; set; }
        
        [JsonProperty(PropertyName = "role")] 
        public string Role { get; set; }
    }
}