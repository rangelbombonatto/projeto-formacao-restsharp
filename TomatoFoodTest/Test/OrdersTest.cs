using Bogus;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using TomatoFoodTest.Model.ResponseSchema;
using TomatoFoodTest.Services;

namespace TomatoFoodTest.Test
{
    public class OrdersTest
    {
        public static string nomeCadastro, emailCadastro, senhaCadastro;
        public static string funcaoGerente = "manager";
        public string funcaoUsuario = "user";

        string dataAtual = DateTime.UtcNow.ToString("yyyy-MM-dd");

        public static string tkn, idUsuario, idRestaurante, idRefeicao;

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
            var responseRegister = responseRS.CadastrarConta(nomeCadastro, emailCadastro, senhaCadastro, senhaCadastro, funcaoGerente);

            idUsuario = responseRegister._id;

            LoginServices responseLS = new LoginServices();

            var response = responseLS.RealizarLogin(emailCadastro, senhaCadastro);

            tkn = response.token;

            RestaurantServices restaurantServices = new RestaurantServices();
            var responseRestaurante = restaurantServices.CadastrarRestaurante("TerraBrasil", "Brasileiro", "Comida Brasileira", "Peixe", "Peixe Assado", "20.87", tkn);

            idRestaurante = responseRestaurante._id;
            idRefeicao = responseRestaurante._meals[0];

        }
        [Test]
        public void DeveCriarComSucessoUmPedido()
        {
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrdem(352.87, idRefeicao, idRestaurante, tkn);

            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(352.87, responseOrder.subtotal);
            Assert.AreEqual(0.05, responseOrder.total_discount);
            Assert.AreEqual(335.2265, responseOrder.total_amount);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idRestaurante, responseOrder._restaurant);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0,10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201, (int)ordersServices.resp.StatusCode);
        }

        [Test]
        public void DeveValidarParticao1()
        {
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrdem(122.40, idRefeicao, idRestaurante, tkn);

            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(122.40, responseOrder.subtotal);
            Assert.AreEqual(0.00, responseOrder.total_discount);
            Assert.AreEqual(122.40, responseOrder.total_amount);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idRestaurante, responseOrder._restaurant);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0, 10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201, (int)ordersServices.resp.StatusCode);
        }

        [Test]
        public void DeveValidarParticao2()
        {
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrdem(324.50, idRefeicao, idRestaurante, tkn);

            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(324.50, responseOrder.subtotal);
            Assert.AreEqual(0.05, responseOrder.total_discount);
            Assert.AreEqual(308.275, responseOrder.total_amount);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idRestaurante, responseOrder._restaurant);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0, 10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201, (int)ordersServices.resp.StatusCode);
        }

        [Test]
        public void DeveValidarParticao3()
        {
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrdem(654.98, idRefeicao, idRestaurante, tkn);

            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(654.98, responseOrder.subtotal);
            Assert.AreEqual(0.08, responseOrder.total_discount);
            Assert.AreEqual(602.5816, responseOrder.total_amount);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idRestaurante, responseOrder._restaurant);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0, 10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201, (int)ordersServices.resp.StatusCode);
        }

        [Test]
        public void DeveValidarParticao4()
        {
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrdem(1196.77, idRefeicao, idRestaurante, tkn);

            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(1196.77, responseOrder.subtotal);
            Assert.AreEqual(0.10, responseOrder.total_discount);
            Assert.AreEqual(1077.093, responseOrder.total_amount);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idRestaurante, responseOrder._restaurant);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0, 10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201, (int)ordersServices.resp.StatusCode);
        }

        [Test]
        public void DeveValidarLimiteInferior250()
        {
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrdem(249.99, idRefeicao, idRestaurante, tkn);

            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(249.99, responseOrder.subtotal);
            Assert.AreEqual(0.00, responseOrder.total_discount);
            Assert.AreEqual(249.99, responseOrder.total_amount);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idRestaurante, responseOrder._restaurant);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0, 10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201, (int)ordersServices.resp.StatusCode);
        }

        [Test]
        public void DeveValidarLimiteSuperior250()
        {
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrdem(250.01, idRefeicao, idRestaurante, tkn);

            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(250.01, responseOrder.subtotal);
            Assert.AreEqual(0.05, responseOrder.total_discount);
            Assert.AreEqual(237.5095, responseOrder.total_amount);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idRestaurante, responseOrder._restaurant);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0, 10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201, (int)ordersServices.resp.StatusCode);
        }

        [Test]
        public void DeveValidarLimiteInferior500()
        {
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrdem(499.99, idRefeicao, idRestaurante, tkn);

            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(499.99, responseOrder.subtotal);
            Assert.AreEqual(0.05, responseOrder.total_discount);
            Assert.AreEqual(474.9905, responseOrder.total_amount);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idRestaurante, responseOrder._restaurant);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0, 10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201, (int)ordersServices.resp.StatusCode);
        }

        [Test]
        public void DeveValidarLimiteSuperior500()
        {
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrdem(500.01, idRefeicao, idRestaurante, tkn);

            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(500.01, responseOrder.subtotal);
            Assert.AreEqual(0.08, responseOrder.total_discount);
            Assert.AreEqual(460.00919999999996, responseOrder.total_amount);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idRestaurante, responseOrder._restaurant);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0, 10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201, (int)ordersServices.resp.StatusCode);
        }

        [Test]
        public void DeveValidarLimiteInferior700()
        {
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrdem(699.99, idRefeicao, idRestaurante, tkn);

            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(699.99, responseOrder.subtotal);
            Assert.AreEqual(0.08, responseOrder.total_discount);
            Assert.AreEqual(643.9908, responseOrder.total_amount);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idRestaurante, responseOrder._restaurant);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0, 10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201, (int)ordersServices.resp.StatusCode);
        }

        [Test]
        public void DeveValidarLimiteSuperior700()
        {
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrdem(700.01, idRefeicao, idRestaurante, tkn);

            Assert.IsNotNull(responseOrder._id);
            Assert.AreEqual("placed", responseOrder.status);
            Assert.AreEqual(700.01, responseOrder.subtotal);
            Assert.AreEqual(0.10, responseOrder.total_discount);
            Assert.AreEqual(630.009, responseOrder.total_amount);
            Assert.AreEqual(idRefeicao, responseOrder._meals[0]);
            Assert.AreEqual(idRestaurante, responseOrder._restaurant);
            Assert.AreEqual(idUsuario, responseOrder._user);
            Assert.AreEqual(dataAtual, responseOrder.created_at.Substring(0, 10));
            Assert.AreEqual(0, responseOrder.__v);
            Assert.AreEqual(201, (int)ordersServices.resp.StatusCode);
        }

        [Test]
        public void DeveValidarTransicaoDeTodosEstadosCorretamente()
        {
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrdem(700.01, idRefeicao, idRestaurante, tkn);

            Assert.AreEqual("placed", responseOrder.status);

            var ordersProcess = ordersServices.AlterarStatusOrdem(tkn, "processing", responseOrder._id);

            Assert.AreEqual("processing", ordersProcess.status);

            var ordersInRota = ordersServices.AlterarStatusOrdem(tkn, "in_route", responseOrder._id);

            Assert.AreEqual("in_route", ordersInRota.status);

            var ordersDelivered = ordersServices.AlterarStatusOrdem(tkn, "delivered", responseOrder._id);

            Assert.AreEqual("delivered", ordersDelivered.status);

            var ordersReceived = ordersServices.AlterarStatusOrdem(tkn, "received", responseOrder._id);

            Assert.AreEqual("received", ordersReceived.status);


        }

        [Test]
        public void DeveValidarTransicaoDePlacedForCanceled()
        {
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrdem(700.01, idRefeicao, idRestaurante, tkn);

            Assert.AreEqual("placed", responseOrder.status);

            var ordersProcess = ordersServices.AlterarStatusOrdem(tkn, "cancelled", responseOrder._id);

            Assert.AreEqual("cancelled", ordersProcess.status);

        }

        [Test]
        public void DeveValidarTransicaoDePlacedForInRoute()
        {
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrdem(700.01, idRefeicao, idRestaurante, tkn);

            Assert.AreEqual("placed", responseOrder.status);

            var ordersProcess = ordersServices.AlterarStatusOrdem(tkn, "in_route", responseOrder._id);

            Assert.AreEqual("Not a valid transition from placed to in_route.", ordersProcess.status);

        }

        [Test]
        public void DeveValidarTransicaoDePlacedForDelivered()
        {
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrdem(700.01, idRefeicao, idRestaurante, tkn);

            Assert.AreEqual("placed", responseOrder.status);

            var ordersProcess = ordersServices.AlterarStatusOrdem(tkn, "delivered", responseOrder._id);

            Assert.AreEqual("Not a valid transition from placed to delivered.", ordersProcess.status);

        }

        [Test]
        public void DeveValidarTransicaoDePlacedForReceived()
        {
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrdem(700.01, idRefeicao, idRestaurante, tkn);

            Assert.AreEqual("placed", responseOrder.status);

            var ordersProcess = ordersServices.AlterarStatusOrdem(tkn, "received", responseOrder._id);

            Assert.AreEqual("Not a valid transition from placed to received.", ordersProcess.status);

        }

        [Test]
        public void DeveExcluirPedidoComSucesso()
        {
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrdem(700.01, idRefeicao, idRestaurante, tkn);

            Assert.AreEqual("placed", responseOrder.status);

            ordersServices.DeletaOrders(tkn, responseOrder._id);

            Assert.AreEqual(204, (int)ordersServices.resp.StatusCode);

        }

        [Test]
        public void DeveBuscarPedidoComSucesso()
        {
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrdem(700.01, idRefeicao, idRestaurante, tkn);

            Assert.AreEqual("placed", responseOrder.status);

            ordersServices.BuscarOrders(tkn, responseOrder._id);

            Assert.AreEqual(200, (int)ordersServices.resp.StatusCode);

        }

        [Test]
        public void NaoDeveCriarPedidoComTokenInvalido()
        {
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrdem(352.87, idRefeicao, idRestaurante, "Bearer 789");

            
            Assert.AreEqual("401-Unauthorized", responseOrder.message);
        }

        [Test]
        public void DeveValidarContratoDaApiOrders()
        {
            OrdersServices ordersServices = new OrdersServices();
            var responseOrder = ordersServices.CriarOrdem(700.01, idRefeicao, idRestaurante, tkn);

            JObject json = JObject.Parse(ordersServices.resp.Content);
            Assert.IsTrue(json.IsValid(OrdersSchema.OrdersJson(), out IList<string> messages), String.Join(",", messages));


        }
    }
}
