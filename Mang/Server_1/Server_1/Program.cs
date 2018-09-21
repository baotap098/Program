using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
namespace Server_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Client in orther computer
            //B1:
            TcpListener ss = new TcpListener(9095);
            ss.Start();
            Socket Client = ss.AcceptSocket();
            //B2:
            NetworkStream ns = new NetworkStream(Client);
            StreamWriter sw = new StreamWriter(ns);
            StreamReader sr = new StreamReader(ns);
            //B3:
            int number = int.Parse(sr.ReadLine());
            if(number % 2 == 0)
            {
                sw.WriteLine(number + " la so CHAN");
            }
            else
            {
                sw.WriteLine(number + " la so LE");
            }
            sw.Flush();
            //B4:
            ss.Stop();
            Client.Close();
            ns.Close();
            sw.Close();
            sr.Close();
        }
    }
}
