using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_032025.DataAccessNetCore.IServices;

namespace BE_032025.DataAccessNetCore.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICategoryGenericRepository CategoryRepository { get; }
        IProductGenericRepository ProductGenericRepository { get; }

        IProductRepositoryDapper ProductRepositoryDapper { get; }
      
        void SaveChange();
        void Dispose();
    }
}
