using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using WatiN.Core;

namespace WebBrowserHandler.Test
{
    [TestFixture]
    public class WebHandlerProxy_WatiN_Test
    {
        private List<IE> lstNavegadores;
        [SetUp]
        public void SetUp()
        {
            lstNavegadores = new List<IE>();
        }
        [TearDown]
        public void TearDown()
        {
            foreach (var navegador in lstNavegadores)
            {
                navegador.Close();
            }
        }
        [Test]
        [STAThread]
        public void GoToUrlTest()
        {
            string url = "www.google.com.br";
            var wProxy = new WatinHandler();
            var ieDriver = wProxy.getDriver;
            lstNavegadores.Add(ieDriver);
            wProxy.getDriver.GoTo(url);

            //Url Ok
            Assert.IsTrue(ieDriver.Url.Contains(url));

            //Closing the IE
            ieDriver.Close();
        }

        [Test]
        [STAThread]
        public void FindButtonTest()
        {
            string url = "www.google.com.br";
            var wProxy = new WatinHandler();
            var ieDriver = wProxy.getDriver;
            lstNavegadores.Add(ieDriver);
            wProxy.getDriver.GoTo(url);

            //Texto
            var pesquisa = wProxy.getDriver.ElementOfType<TextField>("gbqfq");

            pesquisa.TypeText("WatiN");
            pesquisa.KeyPress('\r');

            //Pesquisar
            wProxy.getDriver.Element("gbqfba").Click();

            wProxy.getDriver.WaitForComplete(30);
            
            Assert.IsTrue(wProxy.getDriver.Url.Contains("WatiN"));

            //Closing the IE
            ieDriver.Close();
        }
    }
}
