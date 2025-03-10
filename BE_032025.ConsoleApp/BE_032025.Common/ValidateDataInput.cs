using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.Common
{
    public static class ValidateDataInput
    {
        public static bool CheckValidInputNumber(string inputNumber)
        {
            if (string.IsNullOrEmpty(inputNumber))
            {
                return false;
            }

            inputNumber = inputNumber.Trim();

            if (!int.TryParse(inputNumber, out int num))
            {
                return false;
            }

            int numberInput = int.Parse(inputNumber); // Nhập số nguyên từ bàn phím

            if (numberInput > int.MaxValue)
            {
                return false;
            }

            return true;


        }
        public static int Tham_Tri(int a)
        {
            return a * a;
        }
        public static int Tham_Chieu(out int a) // b
        {
            a = 2000;
            return 2;
        }

        public static int abc(int a, int b, int c)
        {
            return a + b;
        }

        public static int Chia_Hai_So()
        {
            try
            {
                int a = 10;
                int b = 0;
                return a / b;
            }
            catch (DivideByZeroException ex)
            {
               Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source);
            }
            return 0;

        }
    }
}
