using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoFoodTest.Model.Response
{
    public class LoginResponse
    {
        [JsonProperty("success")]
        public bool success {  get; set; }

        [JsonProperty("token")]
        public string token { get; set; }

        [JsonProperty("passwordincorrect")]
        public string passwordincorrect { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }

        [JsonProperty("emailnotfound")]
        public string emailnotfound { get; set; }
    }
}
