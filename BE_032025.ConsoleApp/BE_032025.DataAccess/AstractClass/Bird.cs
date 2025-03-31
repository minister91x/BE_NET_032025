using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.DataAccess.AstractClass
{
    public class Bird : Aninal
    {
        
        public override void Eat()
        {
            Console.WriteLine("ăn sâu");
        }

        public override void MakeSound()
        {
          Console.WriteLine("kêu tiếng chích chòe");
        }
    }
}
