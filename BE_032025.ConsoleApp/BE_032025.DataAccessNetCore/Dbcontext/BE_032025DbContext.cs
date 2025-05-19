using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_032025.DataAccessNetCore.DataObject;
using Microsoft.EntityFrameworkCore;

namespace BE_032025.DataAccessNetCore.Dbcontext
{
    public class BE_032025DbContext : DbContext
    {
        public BE_032025DbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder) { base.OnModelCreating(builder); }
        public virtual DbSet<Product> product { get; set; }
        public virtual DbSet<Category> category { get; set; }
        public virtual DbSet<Account> account { get; set; }
    }
}
