using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.DataAccess.AstractClass
{
    public class HinhVuong : HinhHoc
    {
        public double Canh { get; set; }
        public HinhVuong(double canh)
        {
            Canh = canh;
        }
        public override double TinhChuVi()
        {
            return Canh * 4;
        }
        public override double TinhDienTich()
        {
            return Canh * Canh;
        }
    }
}
