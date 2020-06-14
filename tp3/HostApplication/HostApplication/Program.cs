using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace HostApplication
{
    class Program
    {
        [STAThread]
        static  void Main(string[] args)
        {
            try
            {
                HttpChannel chanel = new HttpChannel(14000);
                ChannelServices.RegisterChannel(chanel, true);
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(HostObject), "HostObject", WellKnownObjectMode.SingleCall);
                Console.WriteLine("Remote Object ready at the server side");
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Error creating/registering the chanel ");
            }

        }
    }
    class HostObject : MarshalByRefObject, RemotingObjects.IRemoteObject
    {
        private int c = 0;
        public String sayHello(String name)
        {
            c++;
            return "Hello " + name + "number of invocation : " + c.ToString();
        }
    }
}
