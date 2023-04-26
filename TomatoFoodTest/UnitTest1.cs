using Bogus;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Collections;

namespace TomatoFoodTest
{
    // Esses testes foram feitos no inicio do curso para exemplificar de forma simples como funciona o framework, não estão sendo mais utilizados, porém manter para anotações.
    public class UnitTest1
    {
        //public RestClient client;
        //public RestRequest endpoint;
        //public IRestResponse resp;

        //public string urlBase = "http://localhost:3000/api/";
        //public string endpointRegistro = "users/register";
        //public string endpointLogin = "users/login";
        //public string endpointRestaurante = "restaurants";
        //public string endpointPedido = "orders";

        //public string nomeCadastro, emailCadastro, senhaCadastro;

        //string dataAtual = DateTime.UtcNow.ToString("dd/MM/yyyy");

        //public void body(object body)
        //{
        //    endpoint.RequestFormat = DataFormat.Json;
        //    endpoint.AddJsonBody(body);
        //}

        //[Test]
        //public void GerarDadosTeste()
        //{
        //    var faker = new Faker();

        //    var nomeFaker = faker.Name.FirstName();
        //    var emailFaker = faker.Internet.Email();
        //    var senhaFaker = faker.Internet.Password();

        //    nomeCadastro = nomeFaker;
        //    emailCadastro = emailFaker;
        //    senhaCadastro = senhaFaker; 
        //}

        //[Test]
        //public void DeveCadastrarUmRegistroComFuncaoGerente()
        //{
        //    client = new RestClient(urlBase);
        //    endpoint = new RestRequest(endpointRegistro);
        //    endpoint.Method = Method.POST;
        //    endpoint.RequestFormat = DataFormat.Json;
        //    body(new
        //    {
        //        name = nomeCadastro,
        //        email = emailCadastro,
        //        password = senhaCadastro,
        //        password2 = senhaCadastro,
        //        role = "manager"
        //    });

        //    resp = client.Execute(endpoint);

        //    JObject resposta = JObject.Parse(resp.Content);
        //    Console.WriteLine(resposta.ToString());

        //    Assert.AreEqual(200, (int)resp.StatusCode);

        //    // pega o conteudo da saida da requisição 
        //    dynamic obj = JProperty.Parse(resp.Content);
        //    var funcao = obj["role"];
        //    var id = obj["_id"];
        //    var nome = obj["name"];
        //    var email = obj["email"];
        //    var senha = obj["password"];
        //    var data = obj["date"];
        //    var versao = obj["__v"];

        //    Assert.AreEqual("manager", Convert.ToString(funcao));
        //    Assert.IsNotNull(id);
        //    Assert.AreEqual(nomeCadastro, Convert.ToString(nome));
        //    Assert.AreEqual(emailCadastro, Convert.ToString(email));
        //    Assert.IsNotNull(senha);
        //    Assert.AreEqual(dataAtual, Convert.ToString(data).Substring(0,10));
        //    Assert.AreEqual(0, Convert.ToInt32(versao));

        //}

        //[Test]
        //public void DeveRealizarLoginComFuncaoGerente()
        //{
        //    client = new RestClient(urlBase);
        //    endpoint = new RestRequest(endpointLogin);
        //    endpoint.Method = Method.POST;
        //    body(new
        //    {
        //        email = "fernando@hotmail.com.br",
        //        password = "123123"
        //    });

        //    resp = client.Execute(endpoint);

        //    JObject resposta = JObject.Parse(resp.Content);
        //    Console.WriteLine(resposta.ToString());

        //}

        //[Test]
        //public void DeveCadastrarRestaurante()
        //{
        //    client = new RestClient(urlBase);
        //    endpoint = new RestRequest(endpointRestaurante);
        //    endpoint.Method = Method.POST;
        //    endpoint.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjY0MzE1OGU2NDY5OGFhNWE5OGU5YzE1YiIsIm5hbWUiOiJGZXJuYW5kbyIsImlhdCI6MTY4MDk3MjM4NSwiZXhwIjoxNzEyNTI5MzExfQ.q-FoURg6ZjcuE9JzKmTZFyHAoN3Q_r6fo1aV0IcnN1I");
        //    body(new
        //    {
        //        name = "Coco Bambu 2",
        //        type = "Comida brasileira",
        //        description = "Comida tipica brasileira",
        //        _meals = new List<object>() { 
        //            new {
        //                name = "Arroz",
        //                price = "23",
        //                description = "Arroz"
        //            },
        //            new {
        //                name = "Feijao",
        //                price = "34.90",
        //                description = "Feijão"
        //            }
        //        }
        //    });

        //    resp = client.Execute(endpoint);

        //    JObject resposta = JObject.Parse(resp.Content);
        //    Console.WriteLine(resposta.ToString());

        //}

        //[Test]
        //public void DeveCadastraPedido()
        //{
        //    client = new RestClient(urlBase);
        //    endpoint = new RestRequest(endpointPedido);
        //    endpoint.Method = Method.POST;
        //    endpoint.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjY0MzE1OGU2NDY5OGFhNWE5OGU5YzE1YiIsIm5hbWUiOiJGZXJuYW5kbyIsImlhdCI6MTY4MDk3MjM4NSwiZXhwIjoxNzEyNTI5MzExfQ.q-FoURg6ZjcuE9JzKmTZFyHAoN3Q_r6fo1aV0IcnN1I");
        //    body(new
        //    {
        //        total_amount = 1158,
        //        _meals = new ArrayList() { "64319d7e4698aa5a98e9c17a", "64319d7e4698aa5a98e9c17b" },
        //        _restaurant = "64319d7e4698aa5a98e9c17e",

        //    });

        //    resp = client.Execute(endpoint);

        //    JObject resposta = JObject.Parse(resp.Content);
        //    Console.WriteLine(resposta.ToString());

        //}


        //[Test]
        //public void DeveBuscarUmPedido()
        //{
        //    client = new RestClient(urlBase);
        //    endpoint = new RestRequest("orders/643aac8be147d7077c1f6f10");
        //    endpoint.Method = Method.GET;
        //    endpoint.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjY0MzE1OGU2NDY5OGFhNWE5OGU5YzE1YiIsIm5hbWUiOiJGZXJuYW5kbyIsImlhdCI6MTY4MDk3MjM4NSwiZXhwIjoxNzEyNTI5MzExfQ.q-FoURg6ZjcuE9JzKmTZFyHAoN3Q_r6fo1aV0IcnN1I");
            

        //    resp = client.Execute(endpoint);

        //    JObject resposta = JObject.Parse(resp.Content);
        //    Console.WriteLine(resposta.ToString());

        //}

        //[Test]
        //public void DeveAlterarStatusDoPedido()
        //{
        //    client = new RestClient(urlBase);
        //    endpoint = new RestRequest("orders/643aac8be147d7077c1f6f10");
        //    endpoint.Method = Method.PUT;
        //    endpoint.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjY0MzE1OGU2NDY5OGFhNWE5OGU5YzE1YiIsIm5hbWUiOiJGZXJuYW5kbyIsImlhdCI6MTY4MDk3MjM4NSwiZXhwIjoxNzEyNTI5MzExfQ.q-FoURg6ZjcuE9JzKmTZFyHAoN3Q_r6fo1aV0IcnN1I");
        //    body(new
        //    {
        //        status = "cancelled"
        //    });

        //    resp = client.Execute(endpoint);

        //    JObject resposta = JObject.Parse(resp.Content);
        //    Console.WriteLine(resposta.ToString());

        //}

        //[Test]
        //public void DeveApagarUmPedido()
        //{
        //    client = new RestClient(urlBase);
        //    endpoint = new RestRequest("orders/643ab005e147d7077c1f6f22");
        //    endpoint.Method = Method.DELETE;
        //    endpoint.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjY0MzE1OGU2NDY5OGFhNWE5OGU5YzE1YiIsIm5hbWUiOiJGZXJuYW5kbyIsImlhdCI6MTY4MDk3MjM4NSwiZXhwIjoxNzEyNTI5MzExfQ.q-FoURg6ZjcuE9JzKmTZFyHAoN3Q_r6fo1aV0IcnN1I");

        //    resp = client.Execute(endpoint);

        //    Assert.AreEqual(204, (int)resp.StatusCode);

        //}
    }
}