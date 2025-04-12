using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_032025.DataAccess.Interface;

namespace BE_032025.DataAccess.Manager
{
    public class BirdManager : IAnimal
    {

        public void Eat()
        {
            // logic 
            Console.WriteLine("ăn sâu");
        }
    }
}
