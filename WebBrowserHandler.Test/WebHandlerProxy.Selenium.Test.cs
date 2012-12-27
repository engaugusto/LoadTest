using NUnit.Framework;
using OpenQA.Selenium.IE;

namespace WebBrowserHandler.Test
{
    [TestFixture]
    public class WebHandlerProxy_Selenium_Test
    {
        [Test]
        public void GoToUrlTest()
        {
            string url = "www.google.com.br";
            var wProxy = new WebHandlerProxy();
            wProxy.Handler = Handler.selenium;
            var webHandler = wProxy.GetWebHandlerSingleton();
            var ieDriver = (InternetExplorerDriver) webHandler.getDriver;
            webHandler.OpenUrl(url);

            Assert.AreEqual(ieDriver.Url, url);
        }
    }
}
