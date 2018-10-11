using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server_Simple_UDP_DoanSo
{
    class Program
    {
        static UdpClient server;
        static IPEndPoint client;
        static byte[] data;
        static String str = "";
        static int numberRandom;
        static void Main(string[] args)
        {

        }
        static void OpenConnetion()
        {
            server = new UdpClient(9001);
            client = new IPEndPoint(IPAddress.Any, 0);
        }
        static void CloseConnetion()
        {
            server.Close();
        }
        static bool SendDataToClient(String str, IPEndPoint client)
        {
            try
            {
                data = Encoding.ASCII.GetBytes(str);
                server.Send(data, data.Length, client);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro Connetion");
            }
            return true;
        }
        static String ReceiveDataFromClient(ref IPEndPoint client)
        {
            String str = "";
            data = server.Receive(ref client);
            str = Encoding.ASCII.GetString(data);
            return str;
        }
        static String[] ConverStringToArr(String str)
        {
            String[] arr = str.Split('_');
            return arr;
        }
        static int ConverStringToInt(String str)
        {
            return int.Parse(str);
        }
    }
}
