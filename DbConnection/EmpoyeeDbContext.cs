using Core_Api_DbConnection_Practice.Model;
using Microsoft.EntityFrameworkCore;

namespace Core_Api_DbConnection_Practice.DbConnection
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options)
        {
            
        }
        public DbSet<Employee> employees{ get; set; }
    }
}
