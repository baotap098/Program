using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client_UDP_2
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient client = new UdpClient("172.0.0.1", 9050);
            IPEndPoint server = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("Nhap so A : ");
            String so = Console.ReadLine();
            Console.WriteLine("Nhap so B : ");
            String so1 = Console.ReadLine();
            byte[] data = Encoding.ASCII.GetBytes(so+"_0");// dong goi du lieu
            client.Send(data, data.Length);// gui di

            byte[] data2 = Encoding.ASCII.GetBytes(so1+"_1");// dong goi du lieu
            client.Send(data2, data2.Length);// gui di

            byte[] data3 = new byte[10];
            data3 = client.Receive(ref server);
            //String kq = Encoding.ASCII.GetString(data3);
            int kq = BitConverter.ToInt16(data3, 0);
            Console.WriteLine(kq);
            Console.ReadLine();

            client.Close();
        }
    }
}
