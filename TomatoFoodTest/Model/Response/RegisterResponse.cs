using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoFoodTest.Model.Response
{
    public class RegisterResponse
    {
        [JsonProperty("role")]
        public string role {  get; set; }

        [JsonProperty("_id")]
        public string _id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }

        [JsonProperty("password2")]
        public string password2 { get; set; }

        [JsonProperty("date")]
        public string date { get; set; }

        [JsonProperty("__v")]
        public int __v { get; set; }


    }
}
