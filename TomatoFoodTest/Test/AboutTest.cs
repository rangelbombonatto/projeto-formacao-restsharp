﻿using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomatoFoodTest.Model.ResponseSchema;
using TomatoFoodTest.Services;

namespace TomatoFoodTest.Test
{
    [TestClass]
    public class AboutTest
    {
        [TestMethod]
        public void ValidaInformacaoAbout()
        {
            AboutServices about = new AboutServices();
            var response = about.About();

            Assert.AreEqual("Sistema de Delivery para Restaurantes", response.about);
            Assert.AreEqual("Tomato Food Brasil", response.name);
            Assert.AreEqual("tomatofood@food.com", response.email);
            Assert.IsTrue(response.open);
            Assert.AreEqual("2022-03-30", response.date);
            Assert.AreEqual(0, response.__v);

            Assert.AreEqual(200, (int)about.resp.StatusCode);

        }

        [TestMethod]
        public void DeveValidarContratoDaApiAbout()
        {
            AboutServices about = new AboutServices();
            var response = about.About();

            JObject json = JObject.Parse(about.resp.Content);

            Assert.IsTrue(json.IsValid(AboutSchema.AboutJson(), out IList<string> messages), String.Join(",", messages));


        }
    }
}
