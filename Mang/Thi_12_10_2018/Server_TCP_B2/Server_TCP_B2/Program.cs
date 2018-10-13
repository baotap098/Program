using System;
using System.IO;
using System.Net.Sockets;

namespace Server_TCP_B2
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
            float[] arr = new float[3];
            for (int i = 0; i < 3; ++i)
            {
                arr[i] = int.Parse(sr.ReadLine());
            }
            Console.WriteLine("a = " + arr[0]);
            Console.WriteLine("b = " + arr[1]);
            Console.WriteLine("c = " + arr[2]);
            if (arr[0] != 0)
            {
                float detal = arr[1] * arr[1] - 4 * arr[0] * arr[2];
                Console.WriteLine(detal + "");
                if (detal < 0) // vo nghiem
                {
                    SendToClient("001");
                    SendToClient("Phuong trinh vo nghiem");
                }
                else
                {
                    if (detal == 0) // co nghiem kep
                    {
                        SendToClient("001");
                        float x = -arr[1] / (2 * arr[0]);
                        SendToClient("Phuong trinh co nghiem kep la :" + x.ToString());
                    }
                    else
                    {
                        if (detal > 0)
                        {
                            SendToClient("002");
                            SendToClient("Phuong trinh co nghiem x1 = " + (-arr[1] - Math.Sqrt(detal)) / (2 * arr[0]) + "");
                            SendToClient("Phuong trinh co nghiem x2 = " + (-arr[1] + Math.Sqrt(detal)) / (2 * arr[0]) + "");
                        }
                    }
                }
            }
            else
            {
                if (arr[1] == 0)
                {
                    if (arr[2] == 0)
                    {
                        SendToClient("001");
                        SendToClient("Phuong trinh vo so nghiem");
                    }
                    else
                    {
                        SendToClient("001");
                        SendToClient("Phuong trinh vo nghiem");
                    }
                }
                else
                {
                    SendToClient("001");
                    SendToClient("Phuong trinh co ngihem duy nhat x = "+ (- arr[2] / arr[1]) + "");
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
            Console.ReadLine();
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
