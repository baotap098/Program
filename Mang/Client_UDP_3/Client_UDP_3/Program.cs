using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Client_UDP_3
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient client = new UdpClient();
            IPEndPoint server = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = new byte[10];
            String dataTemp; // store data convert from data to String.
            String code = "";// code or index.
            String[] dataInfo;// array store include: front: code and back: data.
            
            // Include variable type Time.
            //String timeSystemStart = DateTime.Now.ToString("s.ff");// time when program start first.
            //float timeReceive = float.Parse(timeSystemStart);
            //float timeSend = 0.0f;

            // Input value N
            Console.WriteLine("Nhap so N: ");
            String number = Console.ReadLine();
            int[] dataArry = new int[int.Parse(number)];
            int[] dataFail = new int[int.Parse(number)];
            // Send N to server
            data = Encoding.ASCII.GetBytes(number);
            client.Send(data, data.Length, "127.0.0.1", 123);
            //timeSend = float.Parse(DateTime.Now.ToString("s.ff"));

            // Receive from server
            while (true)
            {
                data = client.Receive(ref server);
                dataTemp = Encoding.ASCII.GetString(data);

                dataInfo = dataTemp.Split(';');

                dataArry[int.Parse(dataInfo[0])] = int.Parse(dataInfo[1]);
            }

            Console.ReadLine();
            client.Close();
        }
    }
}
