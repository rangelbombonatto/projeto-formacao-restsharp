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
    public class LoginServices: BaseServices
    {
        public void BodyLogin(LoginRequest login)
        {
            endpoint.RequestFormat = DataFormat.Json;
            endpoint.AddJsonBody(login);
        }

        public LoginResponse RealizarLogin(string email, string senha)
        {
            Client(urlBase);
            Endpoint("users/login");
            Post();
            BodyLogin(new LoginRequest
            {
                email = email,
                password = senha,
            });

            ExecutaRequest();
            RetornaResposta("Resposta API de Login");

            var response = JsonConvert.DeserializeObject<LoginResponse>(resp.Content);
            return response;

        }
    }
}
