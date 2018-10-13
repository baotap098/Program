using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Client_UDP_B2
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
            for (int i = 0; i < 3; ++i)
            {
                Console.WriteLine("Enter your number:");
                SendDataToSever(Console.ReadLine() + "_" + i);
            }
            String[] arrStr;
            int count = -1;
            int countCorrent = 0;
            do
            {
                str = ReceiveDataFromSever();
                arrStr = ConverStringToArr(str);
                if (arrStr.Length > 1)
                {
                    if (arrStr[1].Equals("code"))
                    {
                        if (arrStr.Length == 2)
                            count = 1;
                        else
                            count = 2;
                    }
                }
                else
                {
                    Console.WriteLine(str);
                    ++countCorrent;
                }
            } while (count != countCorrent);


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
            Console.ReadLine();
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
        static String sendKey()
        {
            Console.WriteLine("Enter your request:");
            String key = "";
            String code = "";
            do
            {
                key = Console.ReadLine();
                SendDataToSever(key);
                code = ReceiveDataFromSever();
                if (code != "000") Console.WriteLine("Tinh nang chua duoc cap nhat. Vui long chon tin nang khac. :(");
            } while (code != "000");
            return key;
        }
        static String[] ConverStringToArr(String str)
        {
            String[] arr = str.Split('_');
            return arr;
        }
        static void Action(String str)
        {
            switch (str)
            {
                case "1":
                    {
                        Console.WriteLine(ReceiveDataFromSever());
                        break;
                    }
                case "2":
                    {
                        String[] arrStr;
                        int[] arr = new int[3];
                        for (int i = 0; i < 3; ++i)
                        {
                            arr[i] = 0;
                        }
                        int count = 0;
                        int countServer = -1;
                        do
                        {
                            str = ReceiveDataFromSever();
                            arrStr = ConverStringToArr(str);
                            if (arrStr.Length == 2)
                            {
                                ++count;
                                arr[int.Parse(arrStr[1])] = int.Parse(arrStr[0]);
                            }
                            else
                            {
                                countServer = int.Parse(arrStr[2]);
                            }

                        } while (count != countServer);
                        for (int i = 0; i < count; ++i)
                        {
                            if (arr[i] != 0)
                                Console.WriteLine(arr[i]);
                        }
                        break;
                    }
            }
        }
    }
}
