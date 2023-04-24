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
    public class RegisterServices : BaseServices
    {
        public string endpointRegistro = "users/register";

        public void BodyRegister(RegisterRequest registro)
        {
            endpoint.RequestFormat = DataFormat.Json;
            endpoint.AddJsonBody(registro);
        }

        public RegisterResponse CadastrarConta(string nome, string email, string senha1, string senha2, string funcao)
        {
            Client(urlBase);
            Endpoint(endpointRegistro);
            Post();
            BodyRegister(new RegisterRequest
            {
                email = email,
                name = nome,
                password = senha1,
                password2 = senha2,
                role = funcao
            });

            ExecutaRequest();
            RetornaResposta("Resposta API de Registro");

            var response = JsonConvert.DeserializeObject<RegisterResponse>(resp.Content);
            return response;

        }
    }
}
