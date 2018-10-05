using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server_UDP_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient server = new UdpClient(9095);
            IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = new byte[10];
            String str = "";
            int index = 0;
            do
            {
                // receive
                data = server.Receive(ref client);
                Console.WriteLine("Client: " + Encoding.ASCII.GetString(data));
                // send
                Console.Write("Sever: ");
                str = Console.ReadLine();
                data = Encoding.ASCII.GetBytes(str + "_" + ++index);
                server.Send(data, data.Length, client);
            } while (str != "bye");

            server.Close();
        }
    }
}
