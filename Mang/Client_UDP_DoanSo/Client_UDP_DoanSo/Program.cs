using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client_UDP_DoanSo
{
    class Program
    {
        static UdpClient client;
        static IPEndPoint server;
        static byte[] data;
        static String str = "";
        static void Main(string[] args)
        {
            OpenConnetion();
            while (true)
            {
                Console.WriteLine("Enter your number:");
                str = Console.ReadLine();
                SendDataToSever(str);
                str = ReceiveDataFromSever();
                Console.WriteLine(str);
            }
            CloseConnetion();
        }
        static bool OpenConnetion()
        {
            client = new UdpClient();
            server = new IPEndPoint(IPAddress.Any, 0);
            return true;
        }
        static void CloseConnetion()
        {
            client.Close();
        }
        static bool SendDataToSever(String str, String ip = "127.0.0.1", int port = 9001)
        {
            data = Encoding.ASCII.GetBytes(str);
            client.Send(data, data.Length, ip, port);
            return true;
        }
        static String ReceiveDataFromSever()
        {
            String str = "";
            data = client.Receive(ref server);
            str = Encoding.ASCII.GetString(data);
            return str;
        }
    }
}
