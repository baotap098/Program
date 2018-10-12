using System;
using System.IO;
using System.Net.Sockets;
namespace Server_TCP_Menu
{
    class Program
    {
        static TcpListener ss;
        static Socket client;
        static NetworkStream ns;
        static StreamReader sr;
        static StreamWriter sw;
        static String str = "";
        static void Main(string[] args)
        {
            OpenConnet();
            int[] arr = new int[3];
            for (int i = 0; i < 3; ++i)
            {
                arr[i] = int.Parse(sr.ReadLine());
            }
            SendToClient("1. So luong cac so le co trong 3 so do.");
            SendToClient("2. Cac so nguyen to co trong 3 so do.");
            SendToClient("3. Thoat.");
            str = receiedKey();

            switch (str)
            {
                case "1":
                    {
                        SendToClient(CountOdd(arr) + "");
                        break;
                    }
                case "2":
                    {
                        for (int i = 0; i < 3; ++i)
                        {
                            if (CheckPrimeNumber(arr[i]))
                                SendToClient(arr[i] + "");
                        }
                        SendToClient("done");
                        break;
                    }
                default:
                    {

                        break;
                    }
            }

            CloseConnet();
        }
        static void OpenConnet()
        {
            //B1: Mo port, ket noi Client
            ss = new TcpListener(7410);
            ss.Start();
            client = ss.AcceptSocket();
            //B2: tao luong
            ns = new NetworkStream(client);
            sr = new StreamReader(ns);
            sw = new StreamWriter(ns);
        }
        static void CloseConnet()
        {
            sr.Close();
            sw.Close();
            ns.Close();
            ss.Stop();
        }
        static void SendToClient(String str)
        {
            sw.WriteLine(str);
            sw.Flush();
        }
        static String ReceiveFromClient()
        {
            return sr.ReadLine();
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
        static String receiedKey()
        {
            String key = "";
            do
            {
                key = sr.ReadLine();
                if (key != "1" && key != "2" && key != "3")
                    sw.WriteLine("001");// sai kieu du lieu
                else
                    sw.WriteLine("000");
                sw.Flush();
            } while (key != "1" && key != "2" && key != "3");
            return key;
        }
    }
}
