using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_032025.DataAccessNetCore.DataObject;
using BE_032025.DataAccessNetCore.Dbcontext;
using BE_032025.DataAccessNetCore.IServices;

namespace BE_032025.DataAccessNetCore.Services
{
    public class ProductGenericRepository : GenericRepository<Product>, IProductGenericRepository
    {
        public ProductGenericRepository(BE_032025DbContext dbContext) : base(dbContext)
        {
        }
    }
   
}
