using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.DataAccess.AstractClass
{
    public abstract class Aninal
    {
        public virtual string Name { get; set; }
        public abstract void Eat();
        public abstract void MakeSound();
        public virtual void Display()
        {
            Console.WriteLine("Name: {0}", Name);
        }
    }
}
