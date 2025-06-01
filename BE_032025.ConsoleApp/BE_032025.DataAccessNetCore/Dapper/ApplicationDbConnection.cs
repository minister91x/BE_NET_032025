using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BE_032025.DataAccessNetCore.Dapper
{
    public class ApplicationDbConnection : IApplicationDbConnection
    {
        public IDbConnection connection { get; private set; }
        public ApplicationDbConnection(IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetConnectionString("ConnStrBE032025"));
        }

        public async Task<int> ExecuteAsync(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.ExecuteAsync(sql, param, transaction, 600, commandType);
        }

        public async Task<List<T>> QueryAsync<T>(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return (await connection.QueryAsync<T>(sql, param, transaction, commandTimeout: 600, commandType: commandType))?.AsList();
        }

        public async  Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction, commandType: commandType);
        }

        public async Task<T> QuerySingleAsync<T>(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.QuerySingleAsync<T>(sql, param, transaction, commandType: commandType);

        }
    }
}
