using WatiN.Core;

namespace WebBrowserHandler
{
    public class WatinHandler
    {
        private IE _ie;

        public IE getDriver
        {
            get { return _ie; }
        }

        public WatinHandler()
        {
            _ie = new IE();
        }
    }
}
