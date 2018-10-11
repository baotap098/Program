using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server_UDP_Mult_1
{
    class Test
    {
        static int MAXSIZE = 100;
        static IPEndPoint[] listClients = new IPEndPoint[MAXSIZE];
        static int numberClients = 0;
        static float[] listSums = new float[MAXSIZE];
        static int[] listNumberOfClients = new int[MAXSIZE];

        static IPEndPoint client;
        static UdpClient server;
        static String str = "";
        static byte[] data;
        static void Main(String[] arg)
        {
            OpenConnetion();
            while (true)
            {
                str = ReceiveDataFromClient(ref client);
                String []arrStr = ConverStringToArr(str);
                int index = IndexOfClientInList(client);
                if(index == -1)
                {

                }
                
                

            }
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
            data = Encoding.ASCII.GetBytes(str);
            server.Send(data, data.Length, client);
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
        static int IndexOfClientInList(IPEndPoint client)
        {
            for (int i = 0; i < listClients.Length; ++i)
                if (listClients[i].Equals(client))
                    return i;
            return -1;
        }
    }
}
