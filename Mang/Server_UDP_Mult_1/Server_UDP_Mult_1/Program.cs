using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server_UDP_Mult_1
{

    class Program
    {
        static int MAXSIZE = 100;
        struct DataClient
        {
            public IPEndPoint client;
            public float[] listNumberOfClientSents;
            public int number;
        }
        static DataClient[] listInfoClients = new DataClient[MAXSIZE];
        static int numberOfListInfoClients = 0;

        static int[] listCountNumber = new int[MAXSIZE];

        static UdpClient server;
        static IPEndPoint client;
        static byte[] data;
        static String str = "";
        static void Main(String[] args)
        {
            OpenConnetion();
            while (true)
            {

                str = ReceiveDataFromClient(ref client);
                String[] arrStr = ConverStringToArr(str);

                int indexClient = IndexOfClient(listInfoClients, client);
                Console.WriteLine(str + " Index =  " + indexClient);

                // when Client is not old Client
                if (indexClient == -1)
                {
                    DataClient dataClient;
                    dataClient.client = client;
                    dataClient.listNumberOfClientSents = new float[MAXSIZE];

                    dataClient.listNumberOfClientSents[int.Parse(arrStr[1])] = float.Parse(arrStr[0]);
                    dataClient.number = 1;
                    listInfoClients[numberOfListInfoClients] = dataClient;
                    numberOfListInfoClients++;

                    Console.WriteLine(listInfoClients[numberOfListInfoClients-1].client.ToString());
                }
                else // when Client is old Client
                {
                    if (arrStr.Length == 2)
                    {

                        listInfoClients[indexClient].listNumberOfClientSents[int.Parse(arrStr[1])] = float.Parse(arrStr[0]);
                        listInfoClients[indexClient].number++;

                        if (listCountNumber[indexClient] != -1)
                        {
                            if (listCountNumber[indexClient] == listInfoClients[indexClient].number)
                            {
                                float sum = 0;
                                for (int i = 0; i < listCountNumber[indexClient]; ++i)
                                {
                                    sum += listInfoClients[indexClient].listNumberOfClientSents[i];
                                }
                                SendDataToClient(sum + "", listInfoClients[indexClient].client);

                                numberOfListInfoClients -= 1;
                                for (int i = indexClient; i < listInfoClients.Length - 1; ++i)
                                {
                                    listInfoClients[i] = listInfoClients[i + 1];
                                    listCountNumber[i] = listCountNumber[i + 1];
                                }
                            }
                        }
                    }
                    else
                    {
                        listCountNumber[indexClient] = int.Parse(arrStr[2]);
                        // show infomation 
                        Console.WriteLine("listCountNumber [" + indexClient + "] =" + listCountNumber[indexClient]);
                        Console.WriteLine("number of listInfoClients [" + indexClient + "]" + listInfoClients[indexClient].number);
                        Console.WriteLine("Client [" + indexClient + "] =" + listInfoClients[indexClient].client.ToString() + " have " + numberOfListInfoClients + " Clients");
                        Console.WriteLine("Number Clients in List Client:" + numberOfListInfoClients);

                        if (listCountNumber[indexClient] == listInfoClients[indexClient].number)
                        {
                            float sum = 0;
                            for (int i = 0; i < listCountNumber[indexClient]; ++i)
                            {
                                sum += listInfoClients[indexClient].listNumberOfClientSents[i];
                            }
                            Console.WriteLine("Sum of Client " + client.ToString() + " la: " + sum);
                            SendDataToClient(sum + "", listInfoClients[indexClient].client);

                            numberOfListInfoClients -= 1;
                            for (int i = indexClient; i < numberOfListInfoClients; ++i)
                            {
                                listInfoClients[i] = listInfoClients[i + 1];
                                listCountNumber[i] = listCountNumber[i + 1];
                            }
                        }
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
        static int IndexOfClient(List<IPEndPoint> listClients, IPEndPoint client)
        {
            int index = 0;
            while (index < listClients.Count && listClients[index] != client) ++index;
            return (index == listClients.Count) ? -1 : index;
        }
        static int IndexOfClient(DataClient[] listClients, IPEndPoint client)
        {
            for (int i = 0; i < numberOfListInfoClients; ++i)
            {
                if (client.Equals(listInfoClients[i].client))
                    return i;
            }
            return -1;
        }
        static int IndexOfClient(List<DataClient> dataClients, IPEndPoint client)
        {
            for (int i = 0; i < dataClients.Count; ++i)
            {
                if (client.Equals(dataClients[i].client))
                    return i;
            }
            return -1;
        }
        static bool CheckFullNumberOfClientSent(int index, String str)
        {

            return true;
        }

    }
}
