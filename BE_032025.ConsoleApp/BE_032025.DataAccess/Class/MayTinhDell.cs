using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_032025.DataAccess.Interface;

namespace BE_032025.DataAccess.Class
{
    public class MayTinhDell : MayViTinh, IAnimal
    {
        // , implement IAnimal
        // : kế thừa từ MayViTinh
        public void Eat()
        {
            throw new NotImplementedException();
        }
    }
}
