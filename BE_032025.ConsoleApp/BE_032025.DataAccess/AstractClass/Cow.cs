using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.DataAccess.AstractClass
{
    public class Cow : Aninal
    {

        public override void Eat()
        {
            Console.WriteLine("Cow is eating grass");
        }
        public override void MakeSound()
        {
            Console.WriteLine("Cow says: Mooooo");
        }
    }

}
