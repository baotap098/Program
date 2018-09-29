using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Server_UDP_3
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient server = new UdpClient(123);
            IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = new byte[10]; // store data type byte array, receive from client.
            String dataTemp = "";
            // Include variable type Time.
            //String timeSystemStart = DateTime.Now.ToString("s.ff");// time when program start first.
            //float time = float.Parse(timeSystemStart);

            //Receive N to client
            data = server.Receive(ref client);
            dataTemp = Encoding.ASCII.GetString(data);
            int n = int.Parse(dataTemp);
            //time = float.Parse(DateTime.Now.ToString("s.ff"));// get value time and convert to float type
            int i = 1;
            int index = 0;

            while (i != n)
            {
                if (n % i == 0)
                {
                    data = Encoding.ASCII.GetBytes(index + ";" + i);
                    server.Send(data, data.Length, client);
                    ++index;
                }
                ++i;
            }

            server.Close();
        }
    }
}
