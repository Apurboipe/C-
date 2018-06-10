using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace client
{
    class Program
    {
        private static Socket s;
        static void Main(string[] args)
        {
            s=new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),1234);
            try
            {
                s.Connect(ipEndPoint);
            }
            catch (Exception)
            {
                Console.Write("Unable to connect remote endpoint \r\n");
                Main(args);
                throw;
            }
            Console.Write("Enter Text");
            string text = Console.ReadLine();
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            s.Send(bytes);
            Console.Write("Data send \r\n");
            Console.Write("Press any key to continue \r\n");
            Console.Read();
            s.Close();


        }
    }
}
