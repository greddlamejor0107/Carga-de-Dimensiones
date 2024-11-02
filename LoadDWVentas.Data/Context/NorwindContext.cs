


using LoadDWVentas.Data.Entities.Northwind;
using LoadDWVentas.Data.Entities.Norwind;
using Microsoft.EntityFrameworkCore;

namespace LoadDWVentas.Data.Context
{
    public partial class NorwindContext : DbContext
    {
        public NorwindContext(DbContextOptions<NorwindContext> options) : base(options)
        {

        }

        #region"Db Sets"
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        #endregion
    }
}
