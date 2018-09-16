using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Client_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //B1: 
            TcpClient cl = new TcpClient("127.0.0.1",123);
            //B2:
            NetworkStream ns = cl.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            StreamReader sr = new StreamReader(ns);
            //B3:
            String soA = "", soB = "";
            String kq = "";
            Console.WriteLine(sr.ReadLine());
            do
            {
                String key = Console.ReadLine();
                sw.WriteLine(key);
                sw.Flush();
                String keySV = sr.ReadLine();
                if (keySV == "nhap_so")
                {
                    Console.WriteLine("Nhap a:");
                    soA = Console.ReadLine();
                    Console.WriteLine("Nhap b:");
                    soB = Console.ReadLine();
                    sw.WriteLine(soA);
                    sw.WriteLine(soB);
                    sw.Flush();
                }
                
                keySV = sr.ReadLine();
                if (keySV == "chon_tinh_nang")
                {
                    Console.WriteLine("Chon Tinh Nang:");
                    do
                    {
                        key = Console.ReadLine();
                        if (key == "1")
                        {
                            Console.WriteLine("da co du lieu roi, chon lai ");
                        }
                    } while (key == "1");
                    sw.WriteLine(key);
                    sw.Flush();
                }
                kq = sr.ReadLine();
                Console.WriteLine(kq);
            }
            while (kq != "thoat") ;
            //B4:
            Console.ReadLine();
            cl.Close();
            ns.Close();
            sw.Close();
            sr.Close();
        }
    }
}
