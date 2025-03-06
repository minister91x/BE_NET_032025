using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BE_032025.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // B1_Nhập số từ bàn phím
            //Console.WriteLine("Nhập Số Thứ Nhất:  ");
            //var input_data = Console.ReadLine();
            //var isNumeric = int.TryParse(input_data, out int n);
            //if (input_data == null || !isNumeric)
            //{
            //    Console.WriteLine("Vui lòng nhập số");
            //}
            //else
            //{

            //    double number1 = Convert.ToDouble(Console.ReadLine());

            //    if (number1 < 0 || number1 > 200)
            //    {
            //        Console.WriteLine("Số vừa nhập là {0}", number1);
            //    }

            //    Console.WriteLine("Số vừa nhập là {0}", number1);
            //}
            //int month = 10;
            //switch (month)
            //{
            //    case 1:
            //    case 3:
            //    case 5:
            //    case 7:
            //    case 8:
            //    case 10:
            //    case 12:
            //        Console.WriteLine($"Tháng {month} có 31 ngày.");
            //        break;
            //    case 4:
            //    case 6:
            //    case 9:
            //    case 11:
            //        Console.WriteLine($"Tháng {month} có 30 ngày.");
            //        break;
            //    case 2:
            //        Console.WriteLine("Tháng 2 có 28 hoặc 29 ngày (năm nhuận).");
            //        break;
            //    default:
            //        Console.WriteLine("Số tháng không hợp lệ.");
            //        break;
            //}

            //input_data = "bac";

            // CTRL+ K + C -> Comment
            // CTRL+ K + U -> UnComment
            //if (month == 2)
            //{
            //}else
            //{

            //}

            // var month2 = month == 2 ? "TRUE" : month == 3 ? "" : "";

            Console.WriteLine("for break");
            Console.WriteLine("-----------------------------------");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("i= {0}", i);
                break;
            }

            Console.WriteLine("-----------------------------------");

            Console.WriteLine("for continue");
            Console.WriteLine("-----------------------------------");
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("i= {0}", i);
                    continue;
                }
            }

            Bai1 bai1 = new Bai1();
            bai1.Hieu_Hai_So(1, 0);

            //Console.WriteLine("Xin chào {0}",name);

        }

    }
}
