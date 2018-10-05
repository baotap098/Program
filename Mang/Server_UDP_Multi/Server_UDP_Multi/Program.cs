using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Server_UDP_Multi
{
    class Program
    {
        static void Main(string[] args)
        {
            //  open port
            UdpClient server = new UdpClient(9095);

            IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);
            List<IPEndPoint> clients = new List<IPEndPoint>();

            List<int> numbers = new List<int>();

            byte[] data;
            int number = 0;
            int sum = 0;
            int index = -1;
            // send and receive data
            while (true)
            {
                data = server.Receive(ref client);
                number = int.Parse(Encoding.ASCII.GetString(data));
                index = -1;
                //
                if (number != 0)
                {
                    Console.WriteLine(number.ToString());
                    Console.WriteLine(client);
                }

                // check client in clients
                for (int i = 0; i < clients.Count; ++i)
                {
                    //Console.WriteLine(clients[i]);
                    if (clients[i].Equals(client))
                    {
                        index = i;
                        break;
                    }
                }

                // print Index
                Console.WriteLine(index.ToString());

                // index != -1 ==> client in clients
                if (index != -1)
                {
                    sum = number + numbers[index];
                    Console.WriteLine(numbers[index] + "+" + number + "=" + sum);
                    clients.RemoveAt(index);
                    numbers.RemoveAt(index);
                    
                    data = Encoding.ASCII.GetBytes(sum + "");
                    server.Send(data, data.Length, client);
                }
                else
                {
                    clients.Add(client);
                    numbers.Add(number);
                }
               
            }


            server.Close();

        }
    }
}
