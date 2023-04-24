using Bogus;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomatoFoodTest.Model.Request;
using TomatoFoodTest.Model.Response;
using TomatoFoodTest.Model.ResponseSchema;
using TomatoFoodTest.Services;

namespace TomatoFoodTest.Test
{
    [TestClass]
    public class RegisterTest
    {
        string dataAtual = DateTime.UtcNow.ToString("yyyy-MM-dd");
        public string nomeCadastro, emailCadastro, senhaCadastro;
        public string funcaoGerente = "manager";
        public string funcaoUsuario = "user";

        [TestInitialize] // Antes de cada metódo é chamado esse teste
        public void GerarDadosTeste()
        {
            var faker = new Faker();

            var nomeFaker = faker.Name.FirstName();
            var emailFaker = faker.Internet.Email();
            var senhaFaker = faker.Internet.Password();

            nomeCadastro = nomeFaker;
            emailCadastro = emailFaker;
            senhaCadastro = senhaFaker;
        }


        [TestMethod]
        public void DeveCadastrarUsuarioComFuncaoGerente()
        {
            RegisterServices response = new RegisterServices();
            var resposta = response.CadastrarConta(nomeCadastro, emailCadastro, senhaCadastro, senhaCadastro, funcaoGerente);

            Assert.AreEqual(funcaoGerente, resposta.role);
            Assert.AreEqual(nomeCadastro, resposta.name);
            Assert.IsNotNull(resposta.password);
            Assert.AreEqual(0, resposta.__v);
            Assert.IsNotNull(resposta._id);
            Assert.AreEqual(emailCadastro, resposta.email);
            Assert.AreEqual(dataAtual, resposta.date.Substring(0, 10));

            Assert.AreEqual(200, (int)response.resp.StatusCode);
        }

        [TestMethod]
        public void DeveCadastrarUsuarioComFuncaoUsuario()
        {
            RegisterServices response = new RegisterServices();
            var resposta = response.CadastrarConta(nomeCadastro, emailCadastro, senhaCadastro, senhaCadastro, funcaoUsuario);

            Assert.AreEqual(funcaoUsuario, resposta.role);
            Assert.AreEqual(nomeCadastro, resposta.name);
            Assert.IsNotNull(resposta.password);
            Assert.AreEqual(0, resposta.__v);
            Assert.IsNotNull(resposta._id);
            Assert.AreEqual(emailCadastro, resposta.email);
            Assert.AreEqual(dataAtual, resposta.date.Substring(0, 10));

            Assert.AreEqual(200, (int)response.resp.StatusCode);
        }

        [TestMethod]
        public void NaoDeveCadastrarUsuarioComNomeVazio()
        {
            RegisterServices response = new RegisterServices();
            var resposta = response.CadastrarConta("", emailCadastro, senhaCadastro, senhaCadastro, funcaoUsuario);

            Assert.AreEqual("Name field is required", resposta.name);
            Assert.AreEqual(400, (int)response.resp.StatusCode);
        }

        [TestMethod]
        public void NaoDeveCadastrarUsuarioComEmailVazio()
        {
            RegisterServices response = new RegisterServices();
            var resposta = response.CadastrarConta(nomeCadastro, "", senhaCadastro, senhaCadastro, funcaoUsuario);

            Assert.AreEqual("Email field is required", resposta.email);
            Assert.AreEqual(400, (int)response.resp.StatusCode);
        }

        [TestMethod]
        public void NaoDeveCadastrarUsuarioComEmailInvalido()
        {
            RegisterServices response = new RegisterServices();
            var resposta = response.CadastrarConta(nomeCadastro, "abc@abc", senhaCadastro, senhaCadastro, funcaoUsuario);

            Assert.AreEqual("Email is invalid", resposta.email);
            Assert.AreEqual(400, (int)response.resp.StatusCode);
        }

        [TestMethod]
        public void NaoDeveCadastrarUsuarioComSenhaVazia()
        {
            RegisterServices response = new RegisterServices();
            var resposta = response.CadastrarConta(nomeCadastro, emailCadastro, "", senhaCadastro, funcaoUsuario);

            Assert.AreEqual("Password must be at least 6 characters", resposta.password);
            Assert.AreEqual(400, (int)response.resp.StatusCode);
        }

        [TestMethod]
        public void NaoDeveCadastrarUsuarioComSenhaDiferentes()
        {
            RegisterServices response = new RegisterServices();
            var resposta = response.CadastrarConta(nomeCadastro, emailCadastro, "123456", "654321", funcaoUsuario);

            Assert.AreEqual("Passwords must match", resposta.password2);
            Assert.AreEqual(400, (int)response.resp.StatusCode);
        }

        [TestMethod]
        public void DeveValidarContratoDaApiRegister()
        {
            RegisterServices response = new RegisterServices();
            var resposta = response.CadastrarConta(nomeCadastro, emailCadastro, senhaCadastro, senhaCadastro, funcaoGerente);

            JObject json = JObject.Parse(response.resp.Content);
            Assert.IsTrue(json.IsValid(RegisterSchema.RegisterJson(), out IList<string> messages), String.Join(",", messages));


        }
    }
}
