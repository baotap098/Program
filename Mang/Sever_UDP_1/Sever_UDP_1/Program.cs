using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace Sever_UDP_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //B1: mo port
            UdpClient server = new UdpClient(9050);

            //B2: trao doi du lieu
            IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);// chuan bi khong gian bo nho chua dia chi va port client
            byte[] data = new byte[10];// chuan bi khong gian bo nho chua du lieu
            data = server.Receive(ref client);//nhan 1 goi tin va thong tin cua client

            byte[] data2 = new byte[10];// chuan bi khong gian bo nho chua du lieu
            data2 = server.Receive(ref client);//nhan 1 goi tin va thong tin cua client
            
            //Console.WriteLine(client.ToString());
            String so = Encoding.ASCII.GetString(data,0,data.Length);
            String so2 = Encoding.ASCII.GetString(data2, 0, data2.Length);
            int a = int.Parse(so);
            int b = int.Parse(so2);
            int tong = a - b;
            data =BitConverter.GetBytes(tong);
            //Console.WriteLine(a+"_"+b);
            //String kq = "";
            //a += b;
            //kq = a + "";
            


            //data = Encoding.ASCII.GetBytes(kq);
            server.Send(data, data.Length, client);
            //B3: dong ket noi
            Console.ReadLine();
            server.Close();


        }
    }
}
