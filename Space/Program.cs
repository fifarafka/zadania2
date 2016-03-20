using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Space
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("http://localhost:9009/Space");
            ServiceHost selfHost = new ServiceHost(typeof(BlackHole), address);

            try
            {
                selfHost.AddServiceEndpoint(typeof(IBlackHole), new WSHttpBinding(), "SpaceServiceEndpoint");
                ServiceMetadataBehavior smd = new ServiceMetadataBehavior();
                smd.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smd);

                selfHost.Open();
                Console.WriteLine("Service is running!");
                Console.ReadLine();
                selfHost.Close();
            }

            catch (CommunicationException error)
            {
                Console.WriteLine("Error: " + error.Message);
            }

            catch (Exception error)
            {
                Console.WriteLine("Error: " + error.Message);
                selfHost.Abort();
            }
        }
    }
}
