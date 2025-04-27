using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.DataAccess.Connection
{
    public class SqlConnectionDB_Genneric : GenericConnectionDatabase<SqlConnection>
    {
        SqlConnection _sqlConnection;
        public override SqlConnection DoConnect()
        {
            var connectString = System.Configuration.ConfigurationManager.ConnectionStrings["BE_032025_ConnectionStringName"].ConnectionString ?? "";
            _sqlConnection = new SqlConnection(connectString);

            if(_sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            return _sqlConnection;

        }
    }
    
}
