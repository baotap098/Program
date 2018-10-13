using System;
using System.IO;
using System.Net.Sockets;

namespace Client_TCP_B2
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
            int soNghiem = 0;
            str = ReceiveFromServer();
            if (str.Equals("001")) // vo nghiem va co nghiem kep
            {

                Console.WriteLine(ReceiveFromServer());
            }
            else
            {
                if (str.Equals("002"))
                {
                    Console.WriteLine(ReceiveFromServer());
                    Console.WriteLine(ReceiveFromServer());
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
