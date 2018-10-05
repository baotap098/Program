using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server_UDP_DoanSo
{
    class Program
    {
        struct DataClient
        {
            public IPEndPoint client;
            public int number;
        }

        static int MAXSIZE = 100;

        static UdpClient server;
        static IPEndPoint client;
        static byte[] data;
        static String str = "";
        static int numberRandom;

        static DataClient[] dataClients = new DataClient[MAXSIZE];
        static int numberDataClient = 0;

        static void Main(string[] args)
        {
            OpenConnetion();
            numberRandom = NumberRandom(0, 100);
            Console.WriteLine("Number random is: " + numberRandom);
            //Console.WriteLine(ReceiveDataFromClient(ref client));
            //Console.ReadLine();
            while (true)
            {
                str = ReceiveDataFromClient(ref client);
                int index = IndexOfClient(dataClients, client);

                if (index == -1) // new Client
                {
                    DataClient dataClient;
                    dataClient.client = client;
                    dataClient.number = ConverStringToInt(str);

                    index = numberDataClient;
                    dataClients[index] = dataClient;

                    if (CheckNumberAndSendRes(dataClients[index], ref numberRandom) == true)
                    {
                        for (int i = 0; i < numberDataClient; ++i)
                        {
                            if (i != index)
                            {
                                SendDataToClient("You lost", dataClients[i].client);
                            }
                        }
                        break;
                    }


                    ++numberDataClient;
                }
                else // old Client
                {
                    dataClients[index].number = ConverStringToInt(str);
                    if (CheckNumberAndSendRes(dataClients[index], ref numberRandom) == true)
                    {
                        for (int i = 0; i < numberDataClient; ++i)
                        {
                            if (i != index)
                            {
                                SendDataToClient("You lost", dataClients[i].client);
                            }
                        }
                        break;
                    }
                }
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
        static int NumberRandom(int min, int max)
        {
            Random rd = new Random();
            return rd.Next(min, max);
        }
        static int IndexOfClient(DataClient[] dataClients, IPEndPoint client)
        {
            for (int i = 0; i < numberDataClient; ++i)
            {
                if (dataClients[i].Equals(client))
                    return i;
            }
            return -1;
        }
        static bool CheckNumberAndSendRes(DataClient dataClient, ref int numberRandom)
        {
            if (dataClient.number == numberRandom)
            {
                SendDataToClient("=", dataClient.client);
                // Reset all Clients
                numberDataClient = 0;
                dataClients = new DataClient[MAXSIZE];

                numberRandom = NumberRandom(0, 100);

                Console.WriteLine("Number random again is: " + numberRandom);
                return true;
            }
            else
            {
                if (dataClient.number < numberRandom)
                    SendDataToClient("<", dataClient.client);
                else
                    SendDataToClient(">", dataClient.client);
            }
            return false;
        }

    }
}
