using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Linq;
using BE_032025.DataAccess;
using BE_032025.DataAccess.Class;
using BE_032025.DataAccess.Manager;
using BE_032025.DataAccess.RequestData;
using BE_032025.DataAccess.Struct;

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

            Console.WriteLine("Product ID ={0} | Name={1}", product.Id, product.Name);


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


            var employeerManager = new Employeer_Manager();

            //var result = employeerManager.Employeer_Insert("<applet", "MR QUÂN", DateTime.Now);

            //switch (result)
            //{
            //    case (int)EmployeerManager_Status.THANH_CONG:
            //        Console.WriteLine("Thêm thành công!");

            //        break;

            //    case (int)EmployeerManager_Status.MA_NHAN_VIEN_KHONG_HOP_LE:
            //        Console.WriteLine("Mã nhân viên không hợp lê!");

            //        break;

            //    case (int)EmployeerManager_Status.TEN_KHONG_HOP_LE:
            //        Console.WriteLine("Tên nhân viên không hợp lê!");

            //        break;
            //}

            //var path = "C:\\Users\\Admin\\Desktop\\Book_Employeer.xlsx";
            //var rs = employeerManager.Employeer_Insert_FromExcelFile(path);

            //var buoi6 = new Bai6_DateTime();
            //buoi6.DateTimeDemo();
            //Console.WriteLine();

            //var emp = new Employeer();
            //emp.EmployeerName = "Mr Quân1234";

            //var car = new Car();
            //car.CarName = "Xe Bus";

            //var function = new Function();

            //var result = function.Phep_Cong<int>(10, 10);
            //Console.WriteLine("Kết quả int: {0}", result);

            //var result2 = function.Phep_Cong<double>(10.5, 10.5);
            //Console.WriteLine("Kết quả double: {0}", result2);

            //var result3 = function.Phep_Cong<string>("Chuoi 1", "Chuoi 2");

            //Console.WriteLine("Kết quả string: {0}", result3);

            //var result4 = function.Phep_Cong<float>(10, 10);
            //Console.WriteLine("Kết quả float: {0}", result4);

            //var result5 = function.Function_DemoStruct<Employeer>(emp);
            //Console.WriteLine("Kết quả Function_DemoStruct: {0}", result5.EmployeerName);

            //var result6 = function.Function_DemoStruct<Car>(car);

            //Console.WriteLine("Kết quả Function_DemoStruct: {0}", result6.CarName);


            //var result7 = new DemoGeneric_WithClass<int>();
            //result7.ThuocTinh = 10;
            //Console.WriteLine("Kết quả DemoGeneric_WithClass: {0}", result7.ThuocTinh);


            //var result8 = new DemoGeneric_WithClass<string>();
            //result8.ThuocTinh = "BE_032025";
            //Console.WriteLine("Kết quả DemoGeneric_WithClass: {0}", result8.ThuocTinh);

            //var result9 = new DemoGeneric_WithClass<Person>();
            //result9.ThuocTinh = new Person
            //{
            //    PersonAddress = "Hà Nội",
            //    PersonName = "MR QUÂN",
            //    PersonPhone = "123"
            //};
            //Console.WriteLine("Kết quả DemoGeneric_WithClass PersonName: {0}", result9.ThuocTinh.PersonName);


            //Dictionary<string, string> _phoneBook = new Dictionary<string, string>()
            //{
            //{"Trump", "0123.456.789" },
            //{"Obama", "0987.654.321" },
            //{"Putin", "0135.246.789" }
            //};


            //Dictionary<int, string> _phoneBookInt = new Dictionary<int, string>()
            //{
            //{1, "0123.456.789" },
            //{2, "0987.654.321" },
            //{3, "0135.246.789" }
            //};


            //foreach (KeyValuePair<string, string> entry in _phoneBook)
            //{
            //    Console.WriteLine($" -> {entry.Key} : {entry.Value}");
            //}


            //ArrayList arrayList = new ArrayList();
            //arrayList.Add(1);
            //arrayList.Add("BE_032025");
            //arrayList.Add(1.5);
            //arrayList.Add(true);

            //foreach (var item in arrayList)
            //{
            //    Console.WriteLine("{0}", item);
            //}



            //Hashtable hashtable = new Hashtable();
            //hashtable.Add("Key1", "Value1");
            //hashtable.Add("Key2", "Value2");
            //Console.WriteLine(hashtable["Key1"]);

            //SortedList mySL = new SortedList();
            //mySL.Add("Third", "!");
            //mySL.Add("Second", "World");
            //mySL.Add("First", "Hello");

            //Console.WriteLine(" Count: {0}", mySL.Count);
            //Console.WriteLine(" Capacity: {0}", mySL.Capacity);
            //Console.WriteLine(" get by Keys: {0}", mySL["First"]);


            //Console.WriteLine(" get by Index: ");
            //Console.WriteLine("\t-KEY-\t-VALUE-");
            //for (int i = 0; i < mySL.Count; i++)
            //{
            //    Console.WriteLine("\t{0}:\t{1}",
            //        mySL.GetKey(i),
            //        mySL.GetByIndex(i));
            //}

            //Stack myStack = new Stack();
            //myStack.Push("Hello");
            //myStack.Push("World");
            //myStack.Push("!");
            //Console.WriteLine("myStack");
            //Console.WriteLine("\tCount: {0}", myStack.Count);
            //Console.Write("\tValues:");
            //foreach (Object obj in myStack) Console.Write(" {0}", obj);


            //Queue myQ = new Queue();
            //myQ.Enqueue("Hello");
            //myQ.Enqueue("World");
            //myQ.Enqueue("!");
            //Console.WriteLine("myQ");
            //Console.WriteLine("\tCount: {0}", myQ.Count); Console.Write("\tValues:");

            //foreach (Object obj in myQ) Console.Write(" {0}", obj);



            //var person = new { Name = "John", Age = 30, City = "New York" };

            //Console.WriteLine("Name: " + person.Name);
            //Console.WriteLine("Age: " + person.Age);
            //Console.WriteLine("City: " + person.City);

            // Đối tương = new Class 
            //var xebus = new DataAccess.Class.MyCar();
            //xebus.Id = 1; // Gán giá trị cho thuộc tính Id
            //xebus.Brand = "Toyota";
            //xebus.Model = "Xe Bus";
            //xebus.Year = 2021;
            //xebus.Color = "Đỏ";


            //xebus.Display_CuaToi();

            //Console.WriteLine("Id: {0}", xebus.Id);
            //Console.WriteLine("Brand: {0}", xebus.Brand);
            //Console.WriteLine("Model: {0}", xebus.Model);
            //Console.WriteLine("Year: {0}", xebus.Year);
            //Console.WriteLine("Color: {0}", xebus.Color);

            //var xecon = new DataAccess.Class.MyCar(2, "MEC", "Xe SIEU SANG", 2025, "Xanh-Đen");

            //Console.WriteLine("Id: {0}-{1}", xecon.Id, 1);
            //Console.WriteLine("Brand: {0}", xecon.Brand);
            //Console.WriteLine("Model: {0}", xecon.Model);
            //Console.WriteLine("Year: {0}", xecon.Year);
            //Console.WriteLine("Color: {0}", xecon.Color);

            var a = 10;
            //var b = "số 2";

            //a = 1000;

            //const int c = 1000; // không thể thay đổi giá trị của c
            //c= 100; // lỗi không thể thay đổi giá trị của c

            //var nhanvien = new Employeer_Partial();
            //nhanvien.ID = 1;
            //nhanvien.Name = "MR QUÂN";
            //nhanvien.Address = "Hà Nội";

            //nhanvien.DoWork();
            //nhanvien.GoToLunch();
            //nhanvien.GoToSLeep();

            //var conbo = new DataAccess.AstractClass.Cow();
            //conbo.Name = "BÒ CÔ BÊ";
            //conbo.MakeSound();


            //var conchim = new DataAccess.AstractClass.Bird();
            //conchim.Name = "Chích chòe";
            //conchim.MakeSound();


            //var hinhvuong = new DataAccess.AstractClass.HinhVuong(5);
            //Console.WriteLine("Diện tích hình vuông: {0}", hinhvuong.TinhDienTich());
            //Console.WriteLine("Chu vi hình vuông: {0}", hinhvuong.TinhChuVi());

            //var person = new PersonClass();
            //// person.
            //Console.WriteLine("GetId: {0}", person.GetId());
            //Console.WriteLine("GetFullName: {0}", person.GetFullName());


            //var maylenovo = new MayTinhLeNoVo();
            //maylenovo.ChieuDai = 10;
            //maylenovo.ChieuRong = 5;

            //maylenovo.UpRAM();


            //var maytinhDell = new MayTinhDell();
            //maytinhDell.ChieuDai = 20;
            //maytinhDell.ChieuRong = 10;
            //maytinhDell.UpRAM();

            //var myKey = System.Configuration.ConfigurationManager.AppSettings["MyKey"] ?? "";

            //if (string.IsNullOrEmpty(myKey))
            //{
            //    return;
            //}

            //if (a == 10)
            //{

            //}

            //var myKey2 = System.Configuration.ConfigurationManager.AppSettings["MyKey"] ?? "";




            //if (a == 10)
            //{

            //}

            //var emp = new Employeer_Partial();
            //var inputData = new Employeer_GoToSleep_InputData
            //{
            //    chan = "chăn",
            //    com = "cơm",
            //    dem = "đêm",
            //    denngu = "đèn ngủ",
            //    dieuhoa = "điều hòa",
            //    giuong = "giường",
            //    goi = "gối",
            //    dem2 = "đêm 2"
            //};
            //emp.GoToSLeep(inputData);

            //emp.GoToSLeep(inputData);


            var productManager = new ProductMangement();
            var requestData = new Product_GetListRequestData
            {
                ProductID = -1
            };

            var list = productManager.Product_GetList(requestData);

            if (list == null || list.Count < 0) { return; }

            foreach (var item in list)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("| ProductID: {0}", item.ProductID + "\t | ProductName" + item.ProductName + "\t CategoryName |" + item.CategoryName);
                Console.WriteLine("----------------------------------------");
            }


            var result = productManager.Product_Insert(new Product_InsertRequestData
            {
                ProductName = "Iphone 20 Pro Max",
                CategoryID = 1,
                ProductImage = "xxxxx"
            });

            if(result > 0)
            {
                Console.WriteLine("Thêm sản phẩm thành công!");
            }
            else
            {
                switch(result)
                {
                    case -1:
                        Console.WriteLine("Thêm sản phẩm thất bại!");
                        break;
                    case -2:
                        Console.WriteLine("Tên sản phẩm đã tồn tại!");
                        break;
                    default:
                        Console.WriteLine("Lỗi không xác định!");
                        break;
                }
            }

        }

    }
}
