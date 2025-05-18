using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_032025.DataAccessNetCore.Dbcontext;
using BE_032025.DataAccessNetCore.IServices;
using Microsoft.EntityFrameworkCore;

namespace BE_032025.DataAccessNetCore.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BE_032025DbContext _dbContext;
        public GenericRepository(BE_032025DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Delete(T t)
        {
            _dbContext.Set<T>().Remove(t);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetList(object param = null)
        {
            return _dbContext.Set<T>().ToList();
        }

        public async Task<List<T>> GetList_NoATracking(object param = null)
        {
            return _dbContext.Set<T>().AsNoTracking().ToList();
        }

        public async Task<int> Insert(T t)
        {
            try
            {
                // check dữ liệu đầu vào 
                if (t == null)
                {
                    throw new Exception("Dữ liệu đầu vào không hợp lệ");
                }

                _dbContext.Set<T>().Add(t);
                // return _dbContext.SaveChangesAsync();

                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(T t)
        {
            try
            {
                _dbContext.Set<T>().Update(t);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
