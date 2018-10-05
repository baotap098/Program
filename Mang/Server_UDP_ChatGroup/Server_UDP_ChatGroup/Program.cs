using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server_UDP_ChatGroup
{
    class Program
    {
        static int MAXSIZE = 100;
        static UdpClient server;
        static IPEndPoint client;
        static byte[] data;
        static String str = "";

        static IPEndPoint[] listClients = new IPEndPoint[MAXSIZE];
        static int numberClientsInList = 0;

        // Can learing next
        static void Main(string[] args)
        {
            OpenConnetion();
            while (true)
            {
                str = ReceiveDataFromClient(ref client);

            }
            CloseConnetion();
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
        static string ReceiveDataFromClient(ref IPEndPoint client)
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
