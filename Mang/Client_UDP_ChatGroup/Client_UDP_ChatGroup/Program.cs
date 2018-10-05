using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client_UDP_ChatGroup
{
    class Program
    {
        static UdpClient client;
        static IPEndPoint server;
        static byte[] data;
        static String str = "";

        // Can learing next
        static void Main(string[] args)
        {
            OpenConnetion();
            while (true)
            {
                
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
