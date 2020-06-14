using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
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
                TcpChannel chanel = new TcpChannel(12000);
                ChannelServices.RegisterChannel(chanel, true);
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(HostObject), "HostObject", WellKnownObjectMode.Singleton);
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
        public String sayHello(String name)
        {
            return "Hello " + name;
        }
    }
}
