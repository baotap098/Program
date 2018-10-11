using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Server_UDP_Menu
{
    class Program
    {
        static UdpClient server;
        static IPEndPoint client;
        static byte[] data;
        static String str = "";
        static void Main(string[] args)
        {
            OpenConnetion();
            int[] arr = new int[3];
            String[] strArr;
            for (int i = 0; i < 3; ++i)
            {
                str = ReceiveDataFromClient(ref client);
                strArr = ConverStringToArr(str);
                arr[int.Parse(strArr[1])] = int.Parse(strArr[0]);
            }
            SendDataToClient("1. So luong cac so le.", client);
            SendDataToClient("2. So nguyen to.", client);
            SendDataToClient("3. Thoat.", client);
            str = receiedKey();

            Action(str, arr);

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
        static String receiedKey()
        {
            String key = "";
            do
            {
                key = ReceiveDataFromClient(ref client);
                if (key != "1" && key != "2" && key != "3")
                    SendDataToClient("001", client);// sai kieu du lieu
                else
                    SendDataToClient("000", client);
            } while (key != "1" && key != "2" && key != "3");
            return key;
        }
        static int CountOdd(int[] arr)
        {
            int count = 0;
            foreach (int obj in arr)
            {
                if (obj % 2 != 0)
                {
                    ++count;
                }
            }
            return count;
        }
        static bool CheckPrimeNumber(int number)
        {
            if (number == 2) return true;
            if (number < 2) return false;
            for (int i = 2; i < number / 2; ++i)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
        static void Action(String str, int[] arr)
        {
            switch (str)
            {
                case "1":
                    {
                        SendDataToClient(CountOdd(arr) + "", client);
                        break;
                    }
                case "2":
                    {
                        int count = 0;
                        for (int i = 0; i < 3; ++i)
                        {
                            if (CheckPrimeNumber(arr[i]))
                            {
                                Console.WriteLine(arr[i]);
                                count++;
                                SendDataToClient(arr[i] + "_" + i, client);
                            }
                        }
                        SendDataToClient("!_!_" + count, client);
                        break;
                    }
            }
        }
    }
}
