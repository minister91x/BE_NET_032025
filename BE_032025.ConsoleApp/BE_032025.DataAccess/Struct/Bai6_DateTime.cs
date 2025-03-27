using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.DataAccess.Struct
{
    public class Bai6_DateTime
    {

        public void DateTimeDemo()
        {
            var dateNow = DateTime.Now;
            var dateUtcNow = DateTime.UtcNow.AddHours(7).AddMinutes(10).AddSeconds(10);
            var dateUtcNowSub = DateTime.UtcNow.AddHours(7).AddMinutes(-10).AddSeconds(-10);

            Console.WriteLine("Date Now: {0}", dateNow);
            Console.WriteLine("dateUtcNow : {0}", dateUtcNow);
            Console.WriteLine(" dateUtcNowSub: {0}", dateUtcNowSub);


            TimeSpan timeSpan = new TimeSpan(-1, 2, 3, 4, 5);

            var dateAddTimeSpan = dateNow.Add(timeSpan);
            Console.WriteLine(" dateAddTimeSpan: {0}", dateAddTimeSpan);

            var MyDate = new DateTime(DateTime.Now.Year, 3, 10);


            // Thời điểm hiện tại.
            //DateTime aDateTime = DateTime.Now;
            //DateTime myBirthDay = new DateTime(1991, 02, 08);

            //// Khoảng cách giữa 2 mốc thời gian => dùng hàm Subtract
            //TimeSpan interval = aDateTime.Subtract(myBirthDay);

            //Console.WriteLine(" interval: {0}",interval.TotalDays);

            DateTime aDateTime = new DateTime(2022, 8, 22, 9, 30, 00);
            // Các định dạng date-time được hỗ trợ.
            //string[] formattedStrings = aDateTime.GetDateTimeFormats();

            //foreach (string format in formattedStrings)
            //{
            //    Console.WriteLine(format);
            //}
            Console.WriteLine(" aDateTime fomat: {0}", aDateTime.ToString("dd/MM/yyyy H:mm:ss"));
            Console.WriteLine(" aDateTime fomat: {0}", aDateTime.ToString("dd-MM-yyyy HH:mm:ss"));


            var dayInMonth = DateTime.DaysInMonth(2025, 3);
            Console.WriteLine(" dayInMonth: {0}", dayInMonth);


            string dateNowString = "10/03/2025";

            DateTime dateValue;
            if (!DateTime.TryParseExact(dateNowString, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out dateValue))
            {
                Console.WriteLine(" Sai định dạng ngày tháng:");
            }
            else
            {
                Console.WriteLine(" đúng định dạng ngày tháng:");

            }

            var myDateTime = DateTime.ParseExact(dateNowString, "dd/MM/yyyy", new CultureInfo("en-US"));

            Console.WriteLine("myDateTime {0}:", myDateTime.ToString("MM/yyyy"));
            // Viết chương trình in ra số ngày mình được sinh ra từ ngày sinh nhật của mình 


            var firstString = "my|Name";
            var secondString = "mrQuan";

            var concat = string.Concat(firstString, secondString);
            Console.WriteLine(" concat: {0}", concat);

            var remove = firstString.Remove(0, 2);
            Console.WriteLine(" remove: {0}", remove);

            var replace = firstString.Replace("my", "your");
            Console.WriteLine(replace);


            var split = firstString.Split('|');
            foreach (var item in split)
            {
                Console.WriteLine("item {0}", item);
            }

            var firstCharacter = "myName|";

            var substring = firstCharacter.Substring(0, firstCharacter.Length - 1);
            Console.WriteLine("substring {0}", substring);

            var stringbuiler = new StringBuilder();
            stringbuiler.Append("myName");  
            stringbuiler.Append("isQuan");

            Console.WriteLine("stringbuiler {0}", stringbuiler.ToString());

        }
    }


}
