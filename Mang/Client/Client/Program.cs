using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //B1: Mo port, ket noi vs Server
            TcpClient cl = new TcpClient("127.0.0.1",123);
            //B2: Tao luon
            NetworkStream ns = cl.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            //B3:Trao doi xl
            Console.WriteLine("Nhap so: ");
            string so = Console.ReadLine();
            sw.WriteLine(so);
            sw.Flush();
            String dem = sr.ReadLine();
            int n = int.Parse(dem);
            String kk = "";
            do
            {
                kk = sr.ReadLine();
                Console.WriteLine(kk);
            } while (kk!="het");
            //for (int i = 0; i<= n; ++i)
            //{
            //    kk = sr.ReadLine();
            //    Console.WriteLine(kk);
            //}
            //Console.WriteLine(kq);
            Console.ReadLine();
            //B4:Dong ket nois
            ns.Close();
            sr.Close();
            sw.Close();
            cl.Close();
        }
    }
}
