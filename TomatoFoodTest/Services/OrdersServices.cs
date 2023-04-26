using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using TomatoFoodTest.Model.Request;
using TomatoFoodTest.Model.Response;

namespace TomatoFoodTest.Services
{
    public class OrdersServices: BaseServices
    {
        public void BodyOrders(object orders)
        {
            endpoint.RequestFormat = DataFormat.Json;
            endpoint.AddJsonBody(orders);
        }

        public OrdersResponse CriarOrdem(double total, string idRefeicao, string idRestaurante, string token)
        {
            Client(urlBase);
            Endpoint("orders");
            Header("Authorization", token);
            Header("Content-Type", "application/json");
            Post();
            BodyOrders(new OrdersRequest
            {
                total_amount = total,
                _meals = new ArrayList() { idRefeicao},
                _restaurant = idRestaurante
               
            });

            ExecutaRequest();
            RetornaResposta("Resposta API de Pedido");

            if (resp.ContentType.Contains(MediaTypeNames.Application.Json))
            {
                var response = JsonConvert.DeserializeObject<OrdersResponse>(resp.Content);
                return response;
            }
            else
            {
                return new OrdersResponse() { message = ($"{(int)resp.StatusCode}-{resp.StatusDescription}") };
            }
        }

        public OrdersResponse AlterarStatusOrdem(string token, string status, string idPedido)
        {
            Client(urlBase);
            Endpoint($"orders/{idPedido}");
            Header("Authorization", token);
            Header("Content-Type", "application/json");
            Put();
            BodyOrders(new 
            {
                status = status

            });

            ExecutaRequest();
            RetornaResposta("Resposta API de Pedido - PUT");

            if (resp.ContentType.Contains(MediaTypeNames.Application.Json))
            {
                var response = JsonConvert.DeserializeObject<OrdersResponse>(resp.Content);
                return response;
            }
            else
            {
                return new OrdersResponse() { message = ($"{(int)resp.StatusCode}-{resp.Content}") };
            }
        }

        public void DeletaOrders(string token, string idPedido)
        {
            Client(urlBase);
            Endpoint($"orders/{idPedido}");
            Header("Authorization", token);
            Header("Content-Type", "application/json");
            Delete();
            
            ExecutaRequest();
            RetornaResposta("Resposta API de Pedido - DELETADO");

            Console.WriteLine($"Pedido {idPedido} deletado!!!");
        }

        public void BuscarOrders(string token, string idPedido)
        {
            Client(urlBase);
            Endpoint($"orders/{idPedido}");
            Header("Authorization", token);
            Header("Content-Type", "application/json");
            Get();

            ExecutaRequest();
            RetornaResposta("Resposta API de Pedido - GET");

            Console.WriteLine($"Pedido {idPedido} encontrado!!!");
        }
    }


}
