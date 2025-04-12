using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.DataAccess.Connection
{
    internal class SqlServerConnection: ConnectionBase
    {
        public override void ConnectoDB()
        {
            // Implement SQL Server connection logic here
            Console.WriteLine("Connected to SQL Server database.");
        }
    }
    
}
