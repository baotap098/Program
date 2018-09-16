using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace Server_5_Menu_C2
{
    class Program
    {
        static TcpListener ss;
        static Socket Client;
        static NetworkStream ns;
        static StreamWriter sw;
        static StreamReader sr;
        static void ini()
        {
            ss = new TcpListener(123);
            ss.Start();
            Client = ss.AcceptSocket();
            //B2:
            ns = new NetworkStream(Client);
            sw = new StreamWriter(ns);
            sr = new StreamReader(ns);
        }
        static void W_Menu()
        {
            sw.WriteLine("1. SO NGUYEN TO.");
            sw.WriteLine("2. TIM MAX.");
            sw.WriteLine("3. UOC SO.");
            sw.WriteLine("4. THOAT.");
            sw.Flush();
        }
        static void close()
        {
            ss.Stop();
            Client.Close();
            ns.Close();
            sw.Close();
            sr.Close();
        }
        static String receiedKey()
        {
            String key = "";
            do
            {
                key = sr.ReadLine();
                if (key != "1" && key != "2" && key != "3" && key != "4")
                    sw.WriteLine("001");// sai kieu du lieu
                else
                    sw.WriteLine("000");
                sw.Flush();
            } while (key != "1" && key != "2" && key != "3" && key != "4");
            return key;
        }
        static void action(String key)
        {
            switch (key)
            {
                case "1":
                    {
                        ct_SoNguyenTo();
                        break;
                    }
                case "2":
                    {
                        ct_Max();
                        break;
                    }
                case "3":
                    {
                        //ct_Thoat();
                        ct_UocSo();
                        break;
                    }
                default:
                    {
                        ct_BaoLoi();
                        break;
                    }
            }
        }

        private static void ct_UocSo()
        {
            String key = "";
            int N = 0;
            bool check = false;
            do
            {
                sw.WriteLine("1. Nhap 1 So.");
                sw.WriteLine("2. In ra cac UOC SO nhon hon so vua nhap.");
                sw.WriteLine("3. Thoat.");
                sw.Flush();
                key = receiedKey();
                acntion_ct_UocSo(key, ref N, ref check);
            } while (key != "3");
            //throw new NotImplementedException();
        }

        private static void acntion_ct_UocSo(string key, ref int N, ref bool check)
        {
            switch (key)
            {
                case "1":
                    {
                        String sN = "";
                        do
                        {
                            erro_002:// xu ly ngoai le, loi sN != so nguyen
                            sN = sr.ReadLine();
                            try
                            {
                                if (sN == "")
                                {
                                    sw.WriteLine("001");
                                    sw.Flush();
                                }
                                else
                                {
                                    N = int.Parse(sN);
                                    sw.WriteLine("000");
                                    sw.Flush();
                                }
                            }
                            catch (Exception e)
                            {
                                sw.WriteLine("002");
                                sw.Flush();
                                goto erro_002;
                            }

                        } while (sN == "");
                        Console.WriteLine(N);
                        check = true;
                        break;
                    }
                case "2":
                    {
                        if (check)
                        {
                            sw.WriteLine("000");
                            for (int i = 2; i < N; ++i)
                                if (N % i == 0)
                                {
                                    sw.WriteLine(i);
                                    sw.Flush();
                                }
                            sw.WriteLine("ok");
                            sw.Flush();
                        }
                        else
                        {
                            sw.WriteLine("001");
                            sw.Flush();
                        }
                        break;
                    }
                case "3":
                    {

                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            //throw new NotImplementedException();
        }

        private static void ct_BaoLoi()
        {
            //throw new NotImplementedException();
        }

        private static void ct_Thoat()
        {
            //throw new NotImplementedException();
        }

        private static void ct_Max()
        {
            String key = "";
            bool check = false;
            int A = 0, B = 0, C = 0;
            //String code = "";
            do
            {
                sw.WriteLine("1. Nhap 3 so.");
                sw.WriteLine("2. Tim max.");
                sw.WriteLine("3. Tro lai.");
                sw.Flush();
                key = receiedKey();
                action_ct_Max(key, ref A, ref B, ref C, ref check);
            } while (key != "3");


            //throw new NotImplementedException();
        }
        static int recedInt()
        {
            int n = 0;
            String x = "";
            bool check = false;
            do
            {
                x = sr.ReadLine();
                if (x == "")
                {
                    sw.WriteLine("001");
                    sw.Flush();
                }
                else
                {
                    try
                    {
                        n = int.Parse(x);
                        sw.WriteLine("000");
                        sw.Flush();
                        check = true;
                    }
                    catch
                    {
                        sw.WriteLine("002");
                        sw.Flush();
                    }
                }
            } while (check == false);

            return n;
        }
        private static void action_ct_Max(String key, ref int a, ref int b, ref int c, ref bool check)
        {
            //int A = 0, B = 0, C = 0;
            switch (key)
            {
                case "1":
                    {
                        a = recedInt();
                        b = recedInt();
                        c = recedInt();
                        Console.WriteLine(a + "_" + b + "_" + c);
                        check = true;
                        break;
                    }
                case "2":
                    {
                        if (check)
                        {
                            int max = a;
                            if (b > max) max = b;
                            if (c > max) max = c;
                            sw.WriteLine("000");
                            sw.WriteLine(max);
                            sw.Flush();
                        }
                        else
                        {
                            sw.WriteLine("002");
                            sw.Flush();
                        }


                        break;
                    }
                case "3":
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            //throw new NotImplementedException();
        }

        static void acntion_ct_SoNguyenTo(String key, ref int N, ref bool check)
        {
            switch (key)
            {
                case "1":
                    {
                        String sN = "";
                        do
                        {
                            erro_002:// xu ly ngoai le, loi sN != so nguyen
                            sN = sr.ReadLine();
                            try
                            {
                                if (sN == "")
                                {
                                    sw.WriteLine("001");
                                    sw.Flush();
                                }
                                else
                                {
                                    N = int.Parse(sN);
                                    sw.WriteLine("000");
                                    sw.Flush();
                                }
                            }
                            catch (Exception e)
                            {
                                sw.WriteLine("002");
                                sw.Flush();
                                goto erro_002;
                            }

                        } while (sN == "");
                        Console.WriteLine(N);
                        check = true;
                        break;
                    }
                case "2":
                    {
                        if (check)
                        {
                            sw.WriteLine("000");
                            for (int i = 2; i < N; ++i)
                                if (ngTo(i))
                                {
                                    sw.WriteLine(i);
                                    sw.Flush();
                                }
                            sw.WriteLine("ok");
                            sw.Flush();
                        }
                        else
                        {
                            sw.WriteLine("001");
                            sw.Flush();
                        }
                        break;
                    }
                case "3":
                    {

                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }

        private static bool ngTo(int x)
        {
            if (x < 1) return false;
            if (x != 2)
                for (int i = 2; i < x; ++i)
                {
                    if (x % i == 0) return false;
                }
            return true;
            //throw new NotImplementedException();
        }

        private static void ct_SoNguyenTo()
        {
            String key = "";
            int N = 0;
            bool check = false;
            do
            {
                sw.WriteLine("1. Nhap 1 So Nguyen.");
                sw.WriteLine("2. In ra cac so NGUYEN TO nhon hon so vua nhap.");
                sw.WriteLine("3. Thoat.");
                sw.Flush();
                key = receiedKey();
                acntion_ct_SoNguyenTo(key, ref N, ref check);
            } while (key != "3");
            //throw new NotImplementedException();
        }

        static void Main(string[] args)
        {
            //B1:
            ini();
            //B3:
            String key = "";
            do
            {
                W_Menu();
                key = receiedKey();
                Console.WriteLine(key);
                action(key);
            } while (key != "4");




            //B4:
            //Console.ReadLine();
            close();
        }
    }
}
