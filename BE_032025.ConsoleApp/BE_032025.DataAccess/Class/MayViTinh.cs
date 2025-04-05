using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.DataAccess.Class
{
    public  class MayViTinh // class CHA
    {
        public string TenMay { get; set; }
        public int ChieuDai { get; set; }
        public int ChieuRong { get; set; }
        public void UpRAM()
        {
            Console.WriteLine("Up RAM");
        }
    }
}
