using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.DataAccess.Class
{
    public class MyCar
    { // Thuộc tính của Car
        // get để lấy giá trị trong thuộc tính,
        // set để gán giá trị cho thuộc tính
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        // Phương thức khởi tạo không tham số
        public MyCar()
        {
        }

        // Phương thức khởi tạo có tham số  
        public MyCar(int id, string brand, string model, int year,string color)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
            Color = color;
        }

        // Phương thức hiển thị thông tin của Car   
        public void Display_CuaToi()
        {
            Console.WriteLine("Id: {0}", Id);
            Console.WriteLine("Brand: {0}", Brand);
            Console.WriteLine("Model: {0}", Model);
            Console.WriteLine("Year: {0}", Year);
            Console.WriteLine("Color: {0}", Color);
        }

        public int Run(int distance)
        {
            return distance;
        }
    }
}
