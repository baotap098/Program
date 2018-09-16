using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace Server_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //B1:
            TcpListener ss = new TcpListener(123);
            ss.Start();
            Socket Client = ss.AcceptSocket();
            //B2:
            NetworkStream ns = new NetworkStream(Client);
            StreamWriter sw = new StreamWriter(ns);
            StreamReader sr = new StreamReader(ns);
            //B3:
            String soA = "";
            String soB = "";
            sw.WriteLine("1. Nhap 2 so; 2. Tich 2 so; 3. Tong 2 so; Phim bat ky de thoat");
            sw.Flush();
            do
            {
                String keyCl = sr.ReadLine();
                if (keyCl == "1")
                {
                    sw.WriteLine("nhap_so");
                    sw.Flush();
                }
                else
                {
                    sw.WriteLine("chua nhap so");
                    sw.Flush();
                }
                soA = sr.ReadLine();
                soB = sr.ReadLine();
                int A = int.Parse(soA);
                int B = int.Parse(soB);
                Console.WriteLine(A + "_" + B);
                sw.WriteLine("chon_tinh_nang");
                sw.Flush();
                keyCl = sr.ReadLine();
                if (keyCl == "2")
                {
                    sw.WriteLine(A * B + "");
                    sw.Flush();
                }
                else
                {
                    if (keyCl == "3")
                    {
                        sw.WriteLine(A + B + "");
                        sw.Flush();
                    }
                    else
                    {
                        sw.WriteLine("thoat");
                        sw.Flush();
                        break;
                    }
                }
            } while (true);
            
              
            //B4:
            Console.ReadLine();
            ss.Stop();
            Client.Close();
            ns.Close();
            sw.Close();
            sr.Close();

        }
    }
}
