using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.ConsoleApp
{
    public class Bai1
    {
        public string Name { get; set; }
        //Hieu
        /// <summary>
        /// Hàm này mục đích để tính hiệu 2 số 
        /// </summary>
        /// <param name="numberA">Số thư nhất</param>
        /// <param name="numberB">Số thứ hai </param>
        public void Hieu_Hai_So(int numberA, int numberB)
        {
            int bienCucBo = 5;
            int y = ++bienCucBo;
            int z = bienCucBo++;

            Console.WriteLine("Hieu la {0}-{1}", y, z);
        }


        public void Hieu_Hai_So_2(int numberA, int numberB)
        {
            Console.WriteLine("Hieu la {0}-{1}", (numberA - numberB), Name);
        }
    }
}
