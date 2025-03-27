using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.DataAccess.Struct
{
    public struct Employeer
    {
        public string EmployeerCode { get; set; }
        public string EmployeerName { get; set; }
        public DateTime StartDate { get; set; }
    }

    public struct Car
    {
        public string CarName { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }
    }

    public class Person
    {
        public string PersonName { get; set; }
        public string PersonAddress { get; set; }
        public string PersonPhone { get; set; }
    }

    public class DemoGeneric_WithClass<T>
    {
        public T ThuocTinh { get; set; }
        public T genericMethod(T genericParameter)
        {
            T rtn = default(T);

            Console.WriteLine("Field type: {0}, value: {1}", typeof(T).ToString(), ThuocTinh);
            Console.WriteLine("Property type: {0}, value: {1}", typeof(T).ToString(), ThuocTinh);
            Console.WriteLine("Parameter type: {0}, value: {1}", typeof(T).ToString(), genericParameter);
            Console.WriteLine("Return type: {0}", typeof(T).ToString());

            return rtn;
        }

    }
}
