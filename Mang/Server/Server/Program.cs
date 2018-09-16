using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //B1: Mo port, ket noi Client
            TcpListener ss = new TcpListener(123);
            ss.Start();
            Socket client = ss.AcceptSocket();
            //B2: tao luong
            NetworkStream ns = new NetworkStream(client);
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            //B3:Trao doi xl
            string so = sr.ReadLine();
            int soA = int.Parse(so);
            string kq = "";
            int dem = 0;
            for(int i = 1; i < soA; ++i)
            {
                if (soA % i == 0)
                {
                    dem++;
                }
            }
            //sw.WriteLine(dem);
            //sw.Flush();
            
            for (int i = 1; i <= soA; ++i)
            {
                if (soA % i == 0)
                {            
                    sw.WriteLine(i+"");
                    //sw.Flush();
                }
            }
            sw.WriteLine("het");
            sw.Flush();
            //B4:Dong ket noi
            sr.Close();
            sw.Close();
            ns.Close();
            ss.Stop();
          
        }
    }
}
