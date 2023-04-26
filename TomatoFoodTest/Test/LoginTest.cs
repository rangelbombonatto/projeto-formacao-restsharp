using Bogus;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using TomatoFoodTest.Model.ResponseSchema;
using TomatoFoodTest.Services;

namespace TomatoFoodTest.Test
{
    public class LoginTest
    {
        public string nomeCadastro, emailCadastro, senhaCadastro;
        public string funcaoGerente = "manager";
        public string funcaoUsuario = "user";

        [SetUp]
        public void DeveRealizarCadastroDeConta()
        {
            var faker = new Faker();

            var nomeFaker = faker.Name.FirstName();
            var emailFaker = faker.Internet.Email();
            var senhaFaker = faker.Internet.Password();

            nomeCadastro = nomeFaker;
            emailCadastro = emailFaker;
            senhaCadastro = senhaFaker;

            RegisterServices responseRS = new RegisterServices();
            responseRS.CadastrarConta(nomeCadastro, emailCadastro, senhaCadastro, senhaCadastro, funcaoUsuario);
        }

        [Test]
        public void DeveRealizarLoginComSucesso()
        {
            LoginServices responseLS = new LoginServices();

            var response = responseLS.RealizarLogin(emailCadastro, senhaCadastro);
            Assert.IsNotNull(response.token);
            Assert.IsTrue(response.success);
        }

        [Test]
        public void NaoDeveRealizarLoginComSenhaInvalida()
        {
            LoginServices responseLS = new LoginServices();

            var response = responseLS.RealizarLogin(emailCadastro, "123123");

            Assert.AreEqual("Password incorrect", response.passwordincorrect);
            Assert.AreEqual(400, (int)responseLS.resp.StatusCode);
        }

        [Test]
        public void NaoDeveRealizarLoginComInformacoesVazias()
        {
            LoginServices responseLS = new LoginServices();

            var response = responseLS.RealizarLogin("", "");

            Assert.AreEqual("Email field is required", response.email);
            Assert.AreEqual("Password field is required", response.password);
            Assert.AreEqual(400, (int)responseLS.resp.StatusCode);
        }

        [Test]
        public void NaoDeveRealizarLoginComEmailNaoCadastrado()
        {
            LoginServices responseLS = new LoginServices();

            var response = responseLS.RealizarLogin("UUU@gmail.com", senhaCadastro);

            Assert.AreEqual("Email not found", response.emailnotfound);
            Assert.AreEqual(404, (int)responseLS.resp.StatusCode);
        }


        [Test]
        public void DeveValidarContratoDaApiLogin()
        {
            LoginServices responseLS = new LoginServices();
            responseLS.RealizarLogin(emailCadastro, senhaCadastro);

            JObject json = JObject.Parse(responseLS.resp.Content);

            Assert.IsTrue(json.IsValid(LoginSchema.LoginJson(), out IList<string> messages), String.Join(",", messages));


        }
    }
}
