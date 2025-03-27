using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.DataAccess
{
    public class Function
    {
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


        //public int Phep_Cong(int a, int b)
        //{
        //    return a + b;
        //}

        //public double Phep_Cong(double a, double b)
        //{
        //    return a + b;
        //}

        //public float Phep_Cong(float a, float b)
        //{
        //    return a + b;
        //}

        public T Function_DemoStruct<T>(T a)
        {
            return a;
        }

        public T Phep_Cong<T>(T a, T b)
        {
            dynamic dx = a, dy = b;
            return dx + dy;
        }

        //public int Phep_Cong(int a, int b, int c)
        //{
        //    return a + b + c;
        //}

        //public int Phep_Cong(int a, int b, int c, int d)
        //{
        //    return a + b + c + d;
        //}

        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }


    }
}
