using NUnit.Framework;
using System;

namespace WebBrowserHandler.Test
{
    [TestFixture]
    public class WebHandlerProxyTest
    {
        [Test]
        public void TestConstructor()
        {
            var wProxy = new WebHandlerProxy();
            Assert.NotNull(wProxy);
        }

        [STAThread]
        [Test]
        public void TestWatiN()
        {
            var wProxy = new WebHandlerProxy();
            wProxy.Handler = Handler.watin;
            Assert.NotNull(wProxy.GetWebHandlerSingleton());
        }

        [Test]
        public void TestSelenium()
        {
            var wProxy = new WebHandlerProxy();
            wProxy.Handler = Handler.selenium;
            Assert.NotNull(wProxy.GetWebHandlerSingleton());
        }
    }
}
