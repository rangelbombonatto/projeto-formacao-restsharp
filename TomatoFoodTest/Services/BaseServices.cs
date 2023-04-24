using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoFoodTest.Services
{
    public class BaseServices
    {
        public RestClient client;
        public RestRequest endpoint;
        public IRestResponse resp;

        public string urlBase = "http://localhost:3000/api/";
        


        public RestClient Client(string url)
        {
            client = new RestClient(url);
            return client;
        }

        public RestRequest Endpoint(string rota)
        {
            endpoint = new RestRequest(rota);
            return endpoint;
        }

        public IRestResponse ExecutaRequest()
        {
            resp = client.Execute(endpoint);
            return resp;
        }

        public void Post()
        {
            endpoint.Method = Method.POST;
            endpoint.RequestFormat = DataFormat.Json;
        }

        public void RetornaResposta(string msgApi)
        {
            JObject resposta = JObject.Parse(resp.Content);
            Console.WriteLine($"{msgApi}");
            Console.WriteLine(resposta.ToString());
        }
    }
}
