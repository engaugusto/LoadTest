using System;
using System.Collections.Generic;
using System.Threading;
using WatiN.Core;
using WebBrowserHandler;
namespace LoadTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var threads = new Queue<Thread>();
            int numMaxThread = 10;
            for (int i = 0; i < numMaxThread; i++)
            {
                var threadNew = new Thread(NewTestWeb);
                threadNew.SetApartmentState(ApartmentState.STA);
                threads.Enqueue(threadNew);
            }

            while(threads.Count != 0)
            {
                var thread = threads.Dequeue();
                thread.Start();
                while(thread.IsAlive){}
            }
        }

        static void NewTestWeb()
        {
            string url = "www.google.com.br";
            var watinHandler = new WatinHandler();
            watinHandler.getDriver.GoTo(url);
            var txtBox = watinHandler.getDriver.ElementOfType<TextField>("gbqfq");
            txtBox.TypeText("Hello World !");

            watinHandler.getDriver.Close();
        }
    }
}
