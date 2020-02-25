using Newtonsoft.Json;

namespace ClientWebApi.Models
{
    public class Dev
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } 
          
        [JsonProperty(PropertyName = "login")] 
        public string GithubUsername { get; set; }

        [JsonProperty(PropertyName = "bio")] 
        public string Bio { get; set; } 

        [JsonProperty(PropertyName = "avatar_url")] 
        public string Avatar { get; set; }
    }
}