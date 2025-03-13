using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE_032025.DataAccess;

namespace BE_032025.ConsoleApp
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.OutputEncoding = System.Text.Encoding.UTF8;

        //    // B1_Nhập số từ bàn phím
        //    //Console.WriteLine("Nhập Số Thứ Nhất:  ");
        //    //var input_data = Console.ReadLine();
        //    //var isNumeric = int.TryParse(input_data, out int n);
        //    //if (input_data == null || !isNumeric)
        //    //{
        //    //    Console.WriteLine("Vui lòng nhập số");
        //    //}
        //    //else
        //    //{

        //    //    double number1 = Convert.ToDouble(Console.ReadLine());

        //    //    if (number1 < 0 || number1 > 200)
        //    //    {
        //    //        Console.WriteLine("Số vừa nhập là {0}", number1);
        //    //    }

        //    //    Console.WriteLine("Số vừa nhập là {0}", number1);
        //    //}
        //    //int month = 10;
        //    //switch (month)
        //    //{
        //    //    case 1:
        //    //    case 3:
        //    //    case 5:
        //    //    case 7:
        //    //    case 8:
        //    //    case 10:
        //    //    case 12:
        //    //        Console.WriteLine($"Tháng {month} có 31 ngày.");
        //    //        break;
        //    //    case 4:
        //    //    case 6:
        //    //    case 9:
        //    //    case 11:
        //    //        Console.WriteLine($"Tháng {month} có 30 ngày.");
        //    //        break;
        //    //    case 2:
        //    //        Console.WriteLine("Tháng 2 có 28 hoặc 29 ngày (năm nhuận).");
        //    //        break;
        //    //    default:
        //    //        Console.WriteLine("Số tháng không hợp lệ.");
        //    //        break;
        //    //}

        //    //input_data = "bac";

        //    // CTRL+ K + C -> Comment
        //    // CTRL+ K + U -> UnComment
        //    //if (month == 2)
        //    //{
        //    //}else
        //    //{

        //    //}

        //    // var month2 = month == 2 ? "TRUE" : month == 3 ? "" : "";

        //    Console.WriteLine("for break");
        //    Console.WriteLine("-----------------------------------");
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine("i= {0}", i);
        //        break;
        //    }

        //    Console.WriteLine("-----------------------------------");

        //    Console.WriteLine("for continue");
        //    Console.WriteLine("-----------------------------------");
        //    for (int i = 0; i < 10; i++)
        //    {
        //        if (i % 2 == 0)
        //        {
        //            Console.WriteLine("i= {0}", i);
        //            continue;
        //        }
        //    }

        //    Bai1 bai1 = new Bai1();
        //    bai1.Hieu_Hai_So(1, 0);



        //    //Console.WriteLine("Xin chào {0}",name);

        //}

        // Bài 4: Tính giai thừa của một số nguyên dương




        // Hàm chính của chương trình
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8; // Đảm bảo hiển thị tiếng Việt đúng cách

            //    int choice; // Biến lưu lựa chọn của người dùng
            //    do
            //    {
            //        // Hiển thị menu chọn bài tập
            //        Console.WriteLine("\nChọn Bài Tập:");
            //        Console.WriteLine("4. Tính giai thừa");
            //        Console.WriteLine("5. Liệt kê số nguyên tố nhỏ hơn n");
            //        Console.WriteLine("6. Kiểm tra số chẵn/lẻ");
            //        Console.WriteLine("7. Kiểm tra số nguyên tố");
            //        Console.WriteLine("8. Hiển thị số bằng chữ");
            //        Console.WriteLine("0. Thoát");
            //        Console.Write("Nhập lựa chọn của bạn: ");

            //        choice = int.Parse(Console.ReadLine()); // Nhận lựa chọn từ người dùng

            //        switch (choice)
            //        {
            //            case 1:
            //               BE_032025.DataAccess.Bai2.TinhGiaiThua(); // Gọi hàm tính giai thừa
            //                break;
            //            case 2:
            //                BE_032025.DataAccess.Bai2.LietKeSoNguyenTo(); // Gọi hàm liệt kê số nguyên tố
            //                break;
            //            case 3:
            //                BE_032025.DataAccess.Bai2.KiemTraChanLe(); // Gọi hàm kiểm tra số chẵn lẻ
            //                break;
            //            case 4:
            //                BE_032025.DataAccess.Bai2.KiemTraSoNguyenTo(); // Gọi hàm kiểm tra số nguyên tố
            //                break;
            //            case 5:
            //                BE_032025.DataAccess.Bai2.HienThiSoBangChu(); // Gọi hàm hiển thị số bằng chữ
            //                break;
            //            case 0:
            //                Console.WriteLine("Thoát Bài Tập."); // Thoát Bài Tập Hoàn Thành
            //                break;
            //            default:
            //                Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập lại."); // Thông báo nhập sai
            //                break;
            //        }

            //    } while (choice != 0); // Lặp lại cho đến khi người dùng chọn 0 để thoát
            //}


            //int a = 100;
            //Console.WriteLine(" before Tham tri {0}", a);
            //Common.ValidateDataInput.Tham_Tri(a);
            //Console.WriteLine(" after Tham tri {0}", a);

            //int b = 1;
            //Console.WriteLine(" before Tham tri {0}", b);
            //var result = Common.ValidateDataInput.Tham_Chieu(out b); // b là tham chiếu của b
            //Console.WriteLine(" after Tham_Chieu {0}- {1}", result, b);

            //try
            //{
            //   BE_032025.DataAccess.Bai3.UserInput("Đây là một chuỗi rất dài ...");
            //}
            //catch (DataTooLongExeption e)
            //{
            //    Console.WriteLine(e.Message +" | ex stacktrace:"+ e.StackTrace );
            //}
            //catch (Exception otherExeption)
            //{
            //    Console.WriteLine(otherExeption.Message);
            //}



            var product = new MyProduct();
            //MyProduct product2 = new MyProduct();

            product.Id = 1;
            product.Name = "Iphone 20 Test";

            Console.WriteLine("Product ID ={0} | Name={1}", product.Id, product.Name)


          int trangthai = 3;
            if (trangthai == 3) // 3 này 
            {

            }
            if (trangthai == (int)TrangThai_ThanhToan.THANH_CONG) // 3 này 
            {

            }

            int[] myArray = { 1, 3, 5, 19 };

            var Length = myArray.Length;

           // var sum = myArray.GetLength

        }

    }
}
