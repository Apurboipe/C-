using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace serverVersion1
{
    class Program
    {
        private static byte[] Buffer { get; set; }
        private static Socket s;
        static void Main(string[] args)
        {
            s=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Bind(new IPEndPoint(0,1234));
            s.Listen(100);

            Socket accepted = s.Accept();
            Buffer = new byte[accepted.SendBufferSize];
            int byteRead = accepted.Receive(Buffer);
            byte[] formated = new byte[byteRead];
            for (int i = 0; i < byteRead; i++)
            {
                formated[i] = Buffer[i];
            }
            string strData = Encoding.ASCII.GetString(formated);
            Console.Write(strData + "\r\n");
            Console.Read();
        }
    }
}
