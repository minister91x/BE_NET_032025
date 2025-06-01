using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_032025.DataAccessNetCore.Dbcontext;
using BE_032025.DataAccessNetCore.IServices;

namespace BE_032025.DataAccessNetCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryGenericRepository CategoryRepository { get; set; }

        public IProductGenericRepository ProductGenericRepository { get; set; }

        public BE_032025DbContext _dbContext { get; set; }

        public IProductRepositoryDapper ProductRepositoryDapper { get; set; }

        public UnitOfWork(ICategoryGenericRepository categoryGenericRepository,
            IProductGenericRepository productGenericRepository , BE_032025DbContext dbContext, IProductRepositoryDapper productRepositoryDapper)
        {
            CategoryRepository = categoryGenericRepository;
            ProductGenericRepository = productGenericRepository;
            _dbContext = dbContext;
            ProductRepositoryDapper = productRepositoryDapper;
        }

        public void SaveChange()
        {
           _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
