using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server_3
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
            Random rd = new Random();
            int soRan = rd.Next(100);
            Console.WriteLine(soRan + "");
            int keySo;
            do
            {
                keySo = int.Parse(sr.ReadLine());
                if (keySo > soRan)
                {
                    sw.WriteLine(keySo + "Lon hon so Server");
                    sw.Flush();
                }
                else
                {
                    if (keySo < soRan)
                    {
                        sw.WriteLine(keySo + "Nho hon so Server");
                        sw.Flush();
                    }
                    else
                    {
                        sw.WriteLine("ok");
                        sw.Flush();
                    }
                }
            } while (keySo!= soRan);
            //B4:
            //Console.ReadLine();
            ss.Stop();
            Client.Close();
            ns.Close();
            sw.Close();
            sr.Close();
        }
    }
}
