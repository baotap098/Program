using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace Client_Simple_UDP_DoanSo
{
    class Program
    {
        static UdpClient client;
        static IPEndPoint server;
        static byte[] data;
        static String str = "";
        static void Main(string[] args)
        {

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
