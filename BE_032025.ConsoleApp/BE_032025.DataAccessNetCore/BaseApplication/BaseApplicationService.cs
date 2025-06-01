using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_032025.DataAccessNetCore.Dapper;
using Microsoft.Extensions.DependencyInjection;

namespace BE_032025.DataAccessNetCore.BaseApplication
{
    public class BaseApplicationService
    {
        protected IApplicationDbConnection DbConnection { get; }

        public BaseApplicationService(IServiceProvider serviceProvider)
        {
            DbConnection = serviceProvider.GetRequiredService<IApplicationDbConnection>(); ;
        }

    }
}
