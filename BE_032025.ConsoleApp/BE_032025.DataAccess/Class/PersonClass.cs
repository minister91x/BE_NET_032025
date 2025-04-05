using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.DataAccess.Class
{
    public class PersonClass
    {
        private int id { get; set; } = 4;
        private string Full_name { get; set; } = "MR Quan";
       /// <summary>
       /// private string last_name { get; set; } = "QUAN";
       /// </summary>
        public string address { get; set; }

        public PersonClass()
        {

        }

        public int GetId()
        {
            return id;
        }

      


        public string GetFullName()
        {
            return Full_name;
        }
    }
}
