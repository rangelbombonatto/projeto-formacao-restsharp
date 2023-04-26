using Bogus;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using TomatoFoodTest.Model.ResponseSchema;
using TomatoFoodTest.Services;

namespace TomatoFoodTest.Test
{
    public class RestaurantTest
    {
        public static string nomeCadastro, emailCadastro, senhaCadastro;
        public static string funcaoGerente = "manager";
        public string funcaoUsuario = "user";

        public static string tkn;

        [OneTimeSetUp]
        public static void DeveRealizarCadastroDeConta()
        {
            var faker = new Faker();

            var nomeFaker = faker.Name.FirstName();
            var emailFaker = faker.Internet.Email();
            var senhaFaker = faker.Internet.Password();

            nomeCadastro = nomeFaker;
            emailCadastro = emailFaker;
            senhaCadastro = senhaFaker;

            RegisterServices responseRS = new RegisterServices();
            responseRS.CadastrarConta(nomeCadastro, emailCadastro, senhaCadastro, senhaCadastro, funcaoGerente);

            LoginServices responseLS = new LoginServices();

            var response = responseLS.RealizarLogin(emailCadastro, senhaCadastro);

            tkn = response.token;
        }

        [Test]
        public void DeveCadastrarComSucessoUmRestaurante()
        {
            RestaurantServices responseRS = new RestaurantServices();
            var response = responseRS.CadastrarRestaurante("TerraBrasil", "Brasileiro", "Comida Brasileira", "Peixe", "Peixe Assado", "20.87", tkn);

            Assert.IsNotNull(response._id);
            Assert.AreEqual("TerraBrasil", response.name);
            Assert.AreEqual("Brasileiro", response.type);
            Assert.AreEqual("Comida Brasileira", response.description);
            Assert.AreEqual(0, response.__v);
            Assert.IsNotNull(response._meals);

            Assert.AreEqual(201, (int)responseRS.resp.StatusCode);

        }

        [Test]
        public void NaoDeveCadastrarRestauranteSemNome()
        {
            RestaurantServices responseRS = new RestaurantServices();
            var response = responseRS.CadastrarRestaurante("", "Brasileiro", "Comida Brasileira", "Peixe", "Peixe Assado", "20.87", tkn);

            Assert.AreEqual("Restaurant validation failed: name: Path `name` is required.", response.message);
            
            Assert.AreEqual(500, (int)responseRS.resp.StatusCode);

        }

        [Test]
        public void NaoDeveCadastrarRestauranteSemTipo()
        {
            RestaurantServices responseRS = new RestaurantServices();
            var response = responseRS.CadastrarRestaurante("TerraBrasil", "", "Comida Brasileira", "Peixe", "Peixe Assado", "20.87", tkn);

            Assert.AreEqual("Restaurant validation failed: type: Path `type` is required.", response.message);

            Assert.AreEqual(500, (int)responseRS.resp.StatusCode);

        }

        [Test]
        public void NaoDeveCadastrarRestauranteSemDescricao()
        {
            RestaurantServices responseRS = new RestaurantServices();
            var response = responseRS.CadastrarRestaurante("TerraBrasil", "Brasileiro", "", "Peixe", "Peixe Assado", "20.87", tkn);

            Assert.AreEqual("Restaurant validation failed: description: Path `description` is required.", response.message);

            Assert.AreEqual(500, (int)responseRS.resp.StatusCode);

        }

        [Test]
        public void NaoDeveCadastrarRestauranteSemNomeRefeicao()
        {
            RestaurantServices responseRS = new RestaurantServices();
            var response = responseRS.CadastrarRestaurante("TerraBrasil", "Brasileiro", "Comida Brasileira", "", "Peixe Assado", "20.87", tkn);

            Assert.AreEqual("Meal validation failed: name: Path `name` is required.", response.message);

            Assert.AreEqual(500, (int)responseRS.resp.StatusCode);

        }

        [Test]
        public void NaoDeveCadastrarRestauranteSemDescricaoRefeicao()
        {
            RestaurantServices responseRS = new RestaurantServices();
            var response = responseRS.CadastrarRestaurante("TerraBrasil", "Brasileiro", "Comida Brasileira", "Peixe", "", "20.87", tkn);

            Assert.AreEqual("Meal validation failed: description: Path `description` is required.", response.message);

            Assert.AreEqual(500, (int)responseRS.resp.StatusCode);

        }

        [Test]
        public void NaoDeveCadastrarRestauranteSemPrecoRefeicao()
        {
            RestaurantServices responseRS = new RestaurantServices();
            var response = responseRS.CadastrarRestaurante("TerraBrasil", "Brasileiro", "Comida Brasileira", "Peixe", "Peixe assado", "", tkn);

            Assert.AreEqual("Meal validation failed: price: Path `price` is required.", response.message);

            Assert.AreEqual(500, (int)responseRS.resp.StatusCode);

        }

        [Test]
        public void NaoDeveCadastrarRestauranteComUsuarioUser()
        {
            RegisterServices responseRS = new RegisterServices();
            responseRS.CadastrarConta(nomeCadastro,"user"+emailCadastro, senhaCadastro, senhaCadastro, funcaoUsuario);

            LoginServices responseLS = new LoginServices();

            var responseLogin = responseLS.RealizarLogin("user"+emailCadastro, senhaCadastro);

            RestaurantServices responseRSS = new RestaurantServices();
            var response = responseRSS.CadastrarRestaurante("TerraBrasil", "Brasileiro", "Comida Brasileira", "Peixe", "Peixe Assado", "20.87", responseLogin.token);

           
            Assert.AreEqual("Forbidden", response.message);

        }

        [Test]
        public void DeveValidarContratoDaApiRestaurante()
        {
            RestaurantServices responseRS = new RestaurantServices();
            var response = responseRS.CadastrarRestaurante("TerraBrasil", "Brasileiro", "Comida Brasileira", "Peixe", "Peixe Assado", "20.87", tkn);

            JObject json = JObject.Parse(responseRS.resp.Content);
            Assert.IsTrue(json.IsValid(RestaurantSchema.RestaurantJson(), out IList<string> messages), String.Join(",", messages));


        }
    }
}
