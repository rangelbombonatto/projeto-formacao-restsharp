using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoFoodTest.Model.Response
{
    public class AboutResponse
    {
        [JsonProperty("about")]
        public string about { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("open")]
        public bool open { get; set; }
    
        [JsonProperty("date")]
        public string date { get; set; }

        [JsonProperty("__v")]
        public int __v { get; set; }
    }
}
