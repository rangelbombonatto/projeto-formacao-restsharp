using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomatoFoodTest.Model.Request;
using TomatoFoodTest.Model.Response;

namespace TomatoFoodTest.Services
{
    public class AboutServices : BaseServices
    { 
        public AboutResponse About()
        {
            Client(urlVirtualizada);
            Endpoint("/about");
            Header("Content-Type", "application/json");
            Get();
            

            ExecutaRequest();
            RetornaResposta("Resposta API de About");

            var response = JsonConvert.DeserializeObject<AboutResponse>(resp.Content);
            return response;

        }
    }
}
