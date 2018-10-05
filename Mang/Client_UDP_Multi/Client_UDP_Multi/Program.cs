using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Client_UDP_Multi
{
    class Program
    {
        static void Main(string[] args)
        {
            // open port
            UdpClient client = new UdpClient();
            IPEndPoint server = new IPEndPoint(IPAddress.Any, 0);
            byte[] data;
            int number = 0;

            // Enter number A
            Console.WriteLine("Nhap A:");
            number = int.Parse(Console.ReadLine());
            data = Encoding.ASCII.GetBytes(number+"");
            client.Send(data, data.Length, "127.0.0.1", 9095);

            // Enter number B
            Console.WriteLine("Nhap B:");
            number = int.Parse(Console.ReadLine());
            data = Encoding.ASCII.GetBytes(number + "");
            client.Send(data, data.Length, "127.0.0.1", 9095);

            // Enter number C
            Console.WriteLine("Nhap C:");
            number = int.Parse(Console.ReadLine());
            data = Encoding.ASCII.GetBytes(number + "");
            client.Send(data, data.Length, "127.0.0.1", 9095);

            // Receive
            data = client.Receive(ref server);
            Console.WriteLine("A + B = " + Encoding.ASCII.GetString(data));

            Console.ReadLine();

            client.Close();

        }
        // 
    }
}
