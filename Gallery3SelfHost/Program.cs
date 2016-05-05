using System;
using System.ServiceModel;
using Gallery3SelfHost;

namespace Gallery3Selfhost
{
    class Program
    {
        static void Main(string[] args)
        {
            //creates a ServiceHost
            using (ServiceHost serviceHost = new ServiceHost(typeof(Service1)))
            {
                //Opens the ServiceHost to create listeners
                //and starts listening for messages
                serviceHost.Open();

                //The service can now be accessed
                Console.WriteLine("The Service is Ready!");
                Console.WriteLine("Please Press <ENTER> to terminate the service.");
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}