using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dang cho ket noi voi Client...");
            //B1:
            TcpListener ss = new TcpListener(123);
            ss.Start();
            Socket Client = ss.AcceptSocket();
            //B2:
            NetworkStream ns = new NetworkStream(Client);
            StreamWriter sw = new StreamWriter(ns);
            StreamReader sr = new StreamReader(ns);
            //B3:
            String key = "";
            String keyCL = "";
            String end = "";
            do
            {
                keyCL = sr.ReadLine();
                Console.WriteLine("Client:" + keyCL);
                Console.WriteLine("Server:");
                do
                {
                    end = Console.ReadLine();
                    key += " " + end;
                } while (end != "");
                sw.WriteLine(key);
                sw.Flush();
            } while (keyCL != "bye");
            Console.WriteLine("Da gui");
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
