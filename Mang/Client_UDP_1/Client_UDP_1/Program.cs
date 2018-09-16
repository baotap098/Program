using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace Client_UDP_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // test dong bo github
            //B1: mo port
            UdpClient client = new UdpClient("127.0.0.1",9050);

            //B2: trao doi du lieu
            Console.WriteLine("Nhap so A : ");
            String so = Console.ReadLine();
            Console.WriteLine("Nhap so B : ");
            String so1 = Console.ReadLine();
            byte[] data = Encoding.ASCII.GetBytes(so);// dong goi du lieu
            client.Send(data, data.Length );// gui di

            byte[] data2 = Encoding.ASCII.GetBytes(so1);// dong goi du lieu
            client.Send(data2, data2.Length);// gui di

            IPEndPoint server = new IPEndPoint(IPAddress.Any, 0);
            byte[] data3 = new byte[10];
            data3 = client.Receive(ref server);
            //String kq = Encoding.ASCII.GetString(data3);
            int kq = BitConverter.ToInt16(data3,0);
            Console.WriteLine(kq);
            Console.ReadLine();
            //B3: dong ket noi
            client.Close();
        }
    }
}
