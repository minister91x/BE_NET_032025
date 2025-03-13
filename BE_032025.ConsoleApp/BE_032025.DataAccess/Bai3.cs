using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_032025.ConsoleApp;

namespace BE_032025.DataAccess
{
    public static class Bai3
    {
        public static void UserInput(string s)
        {
            if (s.Length > 10)
            {
                Exception e = new DataTooLongExeption();
                throw e;    // lỗi văng ra
            }
            //Other code - no exeption
        }

    }

    public struct Category
    {
        public int Id
        {
            get; set;
        }

    }
    public struct MyProduct
    {
        public int Id { get; set; }
        // get là cho phép lấy dữu liệu từ thuộc tinh 
        // set là cho phép đưa giá trị vào thuộc tính
        public string Name { get; set; }

        public Category category { get; set; }


        // Phức thức (hàm)
        // hÀM khởi tạo -> khởi tạo giá trị cho các thuộc tính
        // +Không có kiểu trả về , không có từ khóa return 
        // số lượng tham số = số lượng của thuộc tính 
        // phải khởi tạo tất cả thuộc tính
        // tên hàm khởi tạo phải giống tên của STRUCT
        public MyProduct(int _id, string _name, Category _category)
        {
            Id = _id;
            Name = _name;
            category = _category;
        }

        // Phương thức 
        public string PriceToString()
        {
            return Id.ToString();
        }

    }

    public enum TrangThai_ThanhToan
    {
        THANH_CONG,
        THAT_BAI,
        HOAN_TIEN
    }
}
