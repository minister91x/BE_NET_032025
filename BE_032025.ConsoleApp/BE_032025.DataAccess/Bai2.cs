using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.DataAccess
{
    public static class Bai2
    {
        public static void TinhGiaiThua()
        {
            Console.Write("Nhập một số nguyên dương: ");
            string inputNumber = Console.ReadLine();

            var isValid = BE_032025.Common.ValidateDataInput.CheckValidInputNumber(inputNumber);
            if (!isValid)
            {
                Console.Write("Vui lòng nhập lại ");
            }

            long giaiThua = 1; // Biến lưu kết quả giai thừa

            for (int i = 1; i <= int.Parse(inputNumber); i++)
            {
                giaiThua *= i; // Nhân dồn để tính giai thừa
            }

            Console.WriteLine($"Giai thừa của {int.Parse(inputNumber)} là: {giaiThua}");
        }

        // Bài 5: Liệt kê tất cả các số nguyên tố nhỏ hơn n
        public static void LietKeSoNguyenTo()
        {
            Console.Write("Nhập số nguyên n: ");
            var inputNumber = Console.ReadLine(); ;
            var isValid = BE_032025.Common.ValidateDataInput.CheckValidInputNumber(inputNumber);
            if (!isValid)
            {
                Console.Write("Vui lòng nhập lại ");
            }

            Console.WriteLine($"Các số nguyên tố nhỏ hơn {int.Parse(inputNumber)} là:");
            for (int i = 2; i < int.Parse(inputNumber); i++)
            {
                if (LaSoNguyenTo(i)) // Kiểm tra xem số i có phải số nguyên tố không
                {
                    Console.Write(i + " "); // In ra số nguyên tố
                }
            }
            Console.WriteLine();
        }

        // Bài 6: Kiểm tra số chẵn hay lẻ
        public static void KiemTraChanLe()
        {
            Console.Write("Nhập một số nguyên: ");
            int n = int.Parse(Console.ReadLine());

            if (n % 2 == 0)
                Console.WriteLine($"{n} là số chẵn.");
            else
                Console.WriteLine($"{n} là số lẻ.");
        }

        // Bài 7: Kiểm tra số nguyên tố
        public static void KiemTraSoNguyenTo()
        {
            Console.Write("Nhập một số nguyên: ");
            int n = int.Parse(Console.ReadLine());

            if (LaSoNguyenTo(n))
                Console.WriteLine($"{n} là số nguyên tố.");
            else
                Console.WriteLine($"{n} không phải là số nguyên tố.");
        }

        // Hàm kiểm tra số nguyên tố
        public static bool LaSoNguyenTo(int num)
        {
            if (num < 2) // Số nhỏ hơn 2 không phải số nguyên tố
                return false;
            for (int i = 2; i <= Math.Sqrt(num); i++) // Kiểm tra từ 2 đến căn bậc hai của số đó
            {
                if (num % i == 0) // Nếu chia hết cho bất kỳ số nào trong khoảng trên thì không phải số nguyên tố
                    return false;
            }
            return true; // Nếu không tìm thấy ước số nào thì là số nguyên tố
        }

        // Bài 8: Hiển thị số bằng chữ (0-9)
        public static void HienThiSoBangChu()
        {
            Console.Write("Nhập một số (0-9): ");
            int n = int.Parse(Console.ReadLine());

            // Mảng chứa cách đọc của các số từ 0 đến 9
            string[] SoChuDoc = { "Không", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };

            if (n >= 0 && n <= 9)
                Console.WriteLine($"Số {n} đọc là: {SoChuDoc[n]}"); // Hiển thị cách đọc tương ứng
            else
                Console.WriteLine("Vui lòng nhập số từ 0 đến 9.");
        }
    }
}
