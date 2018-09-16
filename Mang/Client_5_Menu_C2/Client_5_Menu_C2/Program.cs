using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace Client_5_Menu_C2
{
    class Program
    {
        static TcpClient cl ;
        static NetworkStream ns ;
        static StreamWriter sw ;
        static StreamReader sr ;
        static void ini()
        {
            cl = new TcpClient("127.0.0.1", 123);
            //B2:
            ns = cl.GetStream();
            sw = new StreamWriter(ns);
            sr = new StreamReader(ns);
        }
        static void close()
        {
            cl.Close();
            ns.Close();
            sw.Close();
            sr.Close();
        }
        static void W_Menu()
        {
            Console.WriteLine(sr.ReadLine());
            Console.WriteLine(sr.ReadLine());
            Console.WriteLine(sr.ReadLine());
            Console.WriteLine(sr.ReadLine());
        }
        static String sendKey()
        {
            Console.WriteLine("Chon tinh nang:");
            String key = "";
            String code = "";
            do
            {
                key = Console.ReadLine();
                sw.WriteLine(key);
                sw.Flush();
                code = sr.ReadLine();
                if (code != "000") Console.WriteLine("Tinh nang chua duoc cap nhat. Vui long chon tin nang khac. :(");
            } while (code!="000");
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
            do
            {
                Console.Clear();
                Console.WriteLine(sr.ReadLine());
                Console.WriteLine(sr.ReadLine());
                Console.WriteLine(sr.ReadLine());

                key = sendKey();
                action_ct_UocSo(key);
            } while (key != "3");
            //throw new NotImplementedException();
        }

        private static void action_ct_UocSo(string key)
        {
            switch (key)
            {
                case "1":
                    {
                        Console.Clear();
                        Console.WriteLine("Nhap so N:");
                        String sN = "";
                        String code = "";
                        do
                        {
                            sN = Console.ReadLine();
                            sw.WriteLine(sN);
                            sw.Flush();
                            code = sr.ReadLine();
                            if (code != "000")
                                Console.WriteLine("Loi du lieu. " + code);
                        } while (code != "000");

                        break;
                    }
                case "2":
                    {
                        Console.Clear();
                        String code = "";
                        code = sr.ReadLine();
                        if (code == "000")
                        {
                            String item = "";
                            do
                            {
                                item = sr.ReadLine();
                                Console.WriteLine(item);
                            } while (item != "ok");
                        }
                        else
                        {
                            Console.WriteLine("Loi du lieu. " + code);
                        }
                        Console.ReadLine();
                        break;
                    }
                case "3":
                    {

                        break;
                    }
                default:
                    {
                        Console.WriteLine("Tinh nang chua duoc cap nhat.");
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
            //String code = "";
            do
            {
                Console.Clear();
                Console.WriteLine(sr.ReadLine());
                Console.WriteLine(sr.ReadLine());
                Console.WriteLine(sr.ReadLine());
                key = sendKey();
                action_ct_Max(key);
            } while (key != "3");
            
            //throw new NotImplementedException();
        }
        static String sendInt()
        {
            String x = "";
            String code = "";
            do
            {
                
                x = Console.ReadLine();
                sw.WriteLine(x);
                sw.Flush();
                code = sr.ReadLine();
                if (code != "000")
                {
                    Console.WriteLine("Loi du lieu" + code);
                }
            } while (code != "000");
            
            return x;
        }
        private static void action_ct_Max(String key)
        {
            switch (key)
            {
                case "1":
                    {
                        Console.Clear();
                        Console.WriteLine("Nhap so A:");
                        sendInt();
                        Console.Clear();
                        Console.WriteLine("Nhap so B:");
                        sendInt();
                        Console.Clear();
                        Console.WriteLine("Nhap so C:");
                        sendInt();
                        break;
                    }
                case "2":
                    {
                        String code = "";
                        Console.Clear();
                        code = sr.ReadLine();
                        if (code == "000")
                        {
                            Console.WriteLine("Max: " + sr.ReadLine());

                        }
                        else
                        {
                            Console.WriteLine("Loi chua nhap du lieu." + code);
                        }
                        Console.ReadLine();
                        break;
                    }
                case "3":
                    {
                        
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Tinh nang chua duoc cap nhat.");
                        break;
                    }
            }
            //throw new NotImplementedException();
        }

        static void action_ct_SoNguyenTo(String key)
        {
            switch (key)
            {
                case "1":
                    {
                        Console.Clear();
                        Console.WriteLine("Nhap so N:");
                        String sN = "";
                        String code = "";
                        do
                        {
                            sN = Console.ReadLine();
                            sw.WriteLine(sN);
                            sw.Flush();
                            code = sr.ReadLine();
                            if (code != "000")
                                Console.WriteLine("Loi du lieu. "+code);
                        } while (code != "000");
                        
                     break;
                    }
                case "2":
                    {
                        Console.Clear();
                        String code = "";
                        code = sr.ReadLine();
                        if(code =="000")
                        {
                            String item = "";
                            do
                            {
                                item = sr.ReadLine();
                                Console.WriteLine(item);
                            } while (item != "ok");
                        }
                        else
                        {
                            Console.WriteLine("Loi du lieu. "+code);
                        }
                        Console.ReadLine();
                        break;
                    }
                case "3":
                    {

                        break;
                    }
                default:
                    {
                        Console.WriteLine("Tinh nang chua duoc cap nhat.");
                        break;
                    }
            }
        }
        private static void ct_SoNguyenTo()
        {
            String key = "";
            do
            {
                Console.Clear();
                Console.WriteLine(sr.ReadLine());
                Console.WriteLine(sr.ReadLine());
                Console.WriteLine(sr.ReadLine());
                
                key = sendKey();
                action_ct_SoNguyenTo(key);
            } while (key!="3");
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
                Console.Clear();
                W_Menu();
                key = sendKey();
                action(key);
            } while (key != "4");
            
            //B4:
            //Console.ReadLine();
            close();
        }
    }
}
