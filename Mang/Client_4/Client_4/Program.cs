using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Client_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //B1: 
            TcpClient cl = new TcpClient("127.0.0.1", 123);
            //B2:
            NetworkStream ns = cl.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            StreamReader sr = new StreamReader(ns);
            //B3:
            String key = "";
            String keySV = "";
            String end = "";
            do
            {
                Console.WriteLine("Client:");
                do
                {
                    end = Console.ReadLine();
                    key += " "+end;
                } while (end != "");
                Console.WriteLine("Da gui");
                sw.WriteLine(key);
                sw.Flush();
                keySV = sr.ReadLine();
                Console.WriteLine("Server: " + keySV);
            } while (key != "bye");
            
            //B4:
            //Console.ReadLine();
            cl.Close();
            ns.Close();
            sw.Close();
            sr.Close();
        }
    }
}
