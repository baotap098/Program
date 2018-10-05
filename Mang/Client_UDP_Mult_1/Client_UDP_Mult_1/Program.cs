using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Client_UDP_Mult_1
{
    class Program
    {
        static UdpClient client;
        static IPEndPoint server;
        static byte[] data;
        static String str = "";
        static int count = -1;
        static void Main(string[] args)
        {
            OpenConnetion();

            while (str != "?")
            {
                #region Enter number and send to Server
                EnterInfo(ref str, ref count);
                if (str != "?")
                {
                    SendDataToSever(str + "_" + count);
                }
                else // str == "?"
                {
                    SendDataToSever(str + "_" + str +"_"+count);// code end is ?_?_cout
                    break;
                }
                #endregion
            }

            Console.WriteLine(ReceiveDataFromSever());
            Console.ReadLine();
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
        static void EnterInfo(ref String str, ref int count)
        {
            Console.Clear();
            Console.WriteLine("Enter number or ? to END:");
            str = Console.ReadLine();
            ++count;
        }
    }
}
