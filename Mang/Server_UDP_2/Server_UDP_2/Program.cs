using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server_UDP_2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            UdpClient server = new UdpClient(9050);
            IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);

            byte[] data = server.Receive(ref client);
            String dl = Encoding.ASCII.GetString(data);
            String[] arr = dl.Split('_');

            int []arrSo = new int[2];
            int index = int.Parse(arr[1]);
            arrSo[index] = int.Parse(arr[0]);

            data = server.Receive(ref client);
            dl = Encoding.ASCII.GetString(data);
            String[] arr2 = dl.Split('_');
            index = int.Parse(arr2[1]);
            arrSo[index] = int.Parse(arr2[0]);
            Console.WriteLine(arrSo[0] + "_" + arrSo[1]);
            int tong = arrSo[0] - arrSo[1];
            data = Encoding.ASCII.GetBytes(tong + "");
            server.Send(data,data.Length,client);

            server.Close();
        }
    }
}
