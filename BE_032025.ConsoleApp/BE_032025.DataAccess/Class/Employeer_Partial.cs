using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.DataAccess.Class
{
    public partial class Employeer_Partial
    {
        public int ID { get; set; }
        public void DoWork() { }
    }

    /// <summary>
    /// Lớp này dùng để quản lý nhân viên
    /// </summary>
    public partial class Employeer_Partial
    {
        /// <summary>
        /// Tên nhân viên  
        /// </summary>
        public string Name { get; set; }
        public void GoToLunch() { }
    }
    /// <summary>
    /// Lớp này dùng để quản lý nhân viên
    /// </summary>
    public partial class Employeer_Partial
    {

        public string Address { get; set; }

        /// <summary>
        /// Hàm này để đi ngủ
        /// </summary>
        /// <param name="com"></param>
        /// <param name="giuong"></param>
        public void GoToSLeep(Employeer_GoToSleep_InputData inputData)
        {
        }
    }

    public class Employeer_GoToSleep_InputData
    {
        public string com { get; set; }
        public string giuong { get; set; }
        public string chan { get; set; }
        public string goi { get; set; }
        public string denngu { get; set; }
        public string dieuhoa { get; set; }
        public string dem { get; set; }
        // ngày 14/04/2025 thêm tham số 

        public string dem2 { get; set; }
    }
}
