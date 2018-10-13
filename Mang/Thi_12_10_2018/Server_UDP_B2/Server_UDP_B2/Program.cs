using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server_UDP_B2
{
    class Program
    {
        static UdpClient server;
        static IPEndPoint client;
        static byte[] data;
        static String str = "";
        static void Main(string[] args)
        {
            OpenConnetion();
            int[] arr = new int[3];
            String[] strArr;
            for (int i = 0; i < 3; ++i)
            {
                str = ReceiveDataFromClient(ref client);
                strArr = ConverStringToArr(str);
                arr[int.Parse(strArr[1])] = int.Parse(strArr[0]);
            }
            Console.WriteLine("a = " + arr[0]);
            Console.WriteLine("b = " + arr[1]);
            Console.WriteLine("c = " + arr[2]);

            if (arr[0] != 0) // phuong trinh bat 2
            {
                float detal = arr[1] * arr[1] - 4 * arr[0] * arr[2];
                Console.WriteLine(detal + "");
                if (detal < 0) // vo nghiem
                {
                    SendDataToClient("001_code", client);
                    SendDataToClient("Phuong trinh vo nghiem", client);
                }
                else
                {
                    if (detal == 0) // co nghiem kep
                    {
                        SendDataToClient("001_code", client);
                        float x = -arr[1] / (2 * arr[0]);
                        SendDataToClient("Phuong trinh co nghiem kep la :" + x, client);
                    }
                    else
                    {
                        if (detal > 0) // co nghiem phan biet
                        {
                            SendDataToClient("002_code_code", client);
                            SendDataToClient("Phuong trinh co nghiem x1 = " + (-arr[1] - Math.Sqrt(detal)) / (2 * arr[0]), client);
                            SendDataToClient("Phuong trinh co nghiem x2 = " + (-arr[1] + Math.Sqrt(detal)) / (2 * arr[0]), client);
                        }
                    }
                }
            }
            else // phuong trnh bat 1
            {
                if (arr[1] == 0)
                {
                    if (arr[2] == 0)
                    {
                        SendDataToClient("001_code", client);
                        SendDataToClient("Phuong trinh vo so nghiem", client);
                    }
                    else
                    {
                        SendDataToClient("001_code", client);
                        SendDataToClient("Phuong trinh vo nghiem", client);
                    }
                }
                else
                {
                    SendDataToClient("001_code", client);
                    SendDataToClient("Phuong trinh co ngihem duy nhat x = " + (-arr[2] / arr[1]), client);
                }
            }



            CloseConnetion();
        }
        static void OpenConnetion()
        {
            server = new UdpClient(9001);
            client = new IPEndPoint(IPAddress.Any, 0);
        }
        static void CloseConnetion()
        {
            server.Close();
        }
        static bool SendDataToClient(String str, IPEndPoint client)
        {
            try
            {
                data = Encoding.ASCII.GetBytes(str);
                server.Send(data, data.Length, client);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro Connetion");
            }
            return true;
        }
        static String ReceiveDataFromClient(ref IPEndPoint client)
        {
            String str = "";
            data = server.Receive(ref client);
            str = Encoding.ASCII.GetString(data);
            return str;
        }
        static String[] ConverStringToArr(String str)
        {
            String[] arr = str.Split('_');
            return arr;
        }
        static int ConverStringToInt(String str)
        {
            return int.Parse(str);
        }
        static String receiedKey()
        {
            String key = "";
            do
            {
                key = ReceiveDataFromClient(ref client);
                if (key != "1" && key != "2" && key != "3")
                    SendDataToClient("001", client);// sai kieu du lieu
                else
                    SendDataToClient("000", client);
            } while (key != "1" && key != "2" && key != "3");
            return key;
        }
        static int CountOdd(int[] arr)
        {
            int count = 0;
            foreach (int obj in arr)
            {
                if (obj % 2 != 0)
                {
                    ++count;
                }
            }
            return count;
        }
        static bool CheckPrimeNumber(int number)
        {
            if (number == 2) return true;
            if (number < 2) return false;
            for (int i = 2; i < number / 2; ++i)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
        static void Action(String str, int[] arr)
        {
            switch (str)
            {
                case "1":
                    {
                        SendDataToClient(CountOdd(arr) + "", client);
                        break;
                    }
                case "2":
                    {
                        int count = 0;
                        for (int i = 0; i < 3; ++i)
                        {
                            if (CheckPrimeNumber(arr[i]) == true)
                            {
                                Console.WriteLine(arr[i]);
                                count++;
                                SendDataToClient(arr[i] + "_" + i, client);
                            }
                        }
                        SendDataToClient("!_!_" + count, client);
                        break;
                    }
            }
        }
    }
}
