﻿using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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
        public string urlVirtualizada = "http://localhost:3001/api/";


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

        public void Put() 
        {
            endpoint.Method = Method.PUT;
            endpoint.RequestFormat = DataFormat.Json;
        
        }

        public void Delete()
        {
            endpoint.Method = Method.DELETE;
            endpoint.RequestFormat = DataFormat.Json;

        }

        public void Get()
        {
            endpoint.Method = Method.GET;
            endpoint.RequestFormat = DataFormat.Json;

        }

        public void RetornaResposta(string msgApi)
        {

            if (resp.ContentType.Contains(MediaTypeNames.Application.Json)) 
            {
                JObject resposta = JObject.Parse(resp.Content);
                Console.WriteLine($"{msgApi} - {(int)resp.StatusCode}");
                Console.WriteLine(resposta.ToString());
            }
            else
            {
                Console.WriteLine(resp.Content);
            }
           
        }

        public void Header(string chave, string valor)
        {
            endpoint.AddHeader(chave, valor);  
        }
    }
}
