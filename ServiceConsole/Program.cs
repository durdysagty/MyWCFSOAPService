using MyWCFSOAPService;
using System;
using System.ServiceModel;

namespace ServiceConsole
{
    internal class Program
    {
        static void Main()
        {
            using (ServiceHost host = new ServiceHost(typeof(ServiceChat)))
            {
                //host.AddServiceEndpoint(typeof(IService1), new BasicHttpBinding(), "http://localhost:8733/Design_Time_Addresses/MyWCFSOAPService/Service1/");
                host.Open();
                Console.WriteLine("Service is running... Press enter to stop");

                Console.ReadLine();
            }
        }
    }
}
