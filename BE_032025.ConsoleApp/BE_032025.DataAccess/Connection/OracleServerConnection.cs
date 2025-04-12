using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.DataAccess.Connection
{
    public class OracleServerConnection: ConnectionBase
    {
        public override void ConnectoDB()
        {
            // Implement Oracle Server connection logic here
            Console.WriteLine("Connected to Oracle database.");
        }
    }
    
}
