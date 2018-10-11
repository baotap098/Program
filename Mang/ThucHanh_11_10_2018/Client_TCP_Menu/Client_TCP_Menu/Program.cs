using System;
using System.IO;
using System.Net.Sockets;

namespace Client_TCP_Menu
{
    class Program
    {
        static TcpClient cl;
        static NetworkStream ns;
        static StreamReader sr;
        static StreamWriter sw;
        static String str;
        static void Main(string[] args)
        {
            OpenConnet();
            for (int i = 0; i < 3; ++i)
            {
                Console.WriteLine("Nhap so: ");
                SendToServer(Console.ReadLine());
            }

            Console.WriteLine(ReceiveFromServer());
            Console.WriteLine(ReceiveFromServer());
            Console.WriteLine(ReceiveFromServer());
            Console.WriteLine("Enter your request:");
            str = sendKey();


            switch (str)
            {
                case "1":
                    {
                        Console.WriteLine(ReceiveFromServer());
                        break;
                    }
                case "2":
                    {
                        do
                        {
                            str = ReceiveFromServer();
                            if (!str.Equals("done"))
                                Console.WriteLine(str);
                        } while (!str.Equals("done"));

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
            //B1: Mo port, ket noi vs Server
            cl = new TcpClient("127.0.0.1", 7410);
            //B2: Tao luon
            ns = cl.GetStream();
            sr = new StreamReader(ns);
            sw = new StreamWriter(ns);
        }
        static void CloseConnet()
        {
            Console.ReadLine();
            ns.Close();
            sr.Close();
            sw.Close();
            cl.Close();
        }
        static void SendToServer(String str)
        {
            sw.WriteLine(str);
            sw.Flush();
        }
        static String ReceiveFromServer()
        {
            return sr.ReadLine();
        }
        static String sendKey()
        {
            Console.WriteLine("Chon tinh nang:");
            String key = "";
            String code = "";
            do
            {
                key = Console.ReadLine();
                sw.WriteLine(key);
                sw.Flush();
                code = sr.ReadLine();
                if (code != "000") Console.WriteLine("Tinh nang chua duoc cap nhat. Vui long chon tin nang khac. :(");
            } while (code != "000");
            return key;
        }
    }
}
