using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using TomatoFoodTest.Model.Request;
using TomatoFoodTest.Model.Response;

namespace TomatoFoodTest.Services
{
    public class RestaurantServices : BaseServices
    {
        public void BodyRestaurant(RestaurantRequest restaurant)
        {
            endpoint.RequestFormat = DataFormat.Json;
            endpoint.AddJsonBody(restaurant);
        }

        public RestaurantResponse CadastrarRestaurante(string nomeRest, string tipoRest, string descRest, string nomeMeal, string descMeal, string precoMeal, string token)
        {
            Client(urlBase);
            Endpoint("restaurants");
            Header("Authorization", token);
            Header("Content-Type", "application/json");
            Post();
            BodyRestaurant(new RestaurantRequest
            {
                name = nomeRest,
                type = tipoRest,
                description = descRest,
                _meals = new List<Meal>() { new Meal { name = nomeMeal, price = precoMeal, description = descMeal } },
            });

            ExecutaRequest();
            RetornaResposta("Resposta API de Restaurante");

            if (resp.ContentType.Contains(MediaTypeNames.Text.Plain))
            {
                return new RestaurantResponse() { message = resp.Content }; 
            }
            else
            {
                var response = JsonConvert.DeserializeObject<RestaurantResponse>(resp.Content);
                return response;
            }
        }
    }
}
