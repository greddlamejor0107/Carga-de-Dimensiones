

using LoadDWVentas.Data.Entities.DwVentas;
using Microsoft.EntityFrameworkCore;

namespace LoadDWVentas.Data.Context
{
    public class NorthwindOrder : DbContext
    {
        public NorthwindOrder(DbContextOptions<NorthwindOrder> options) : base(options) 
        {
            
        }

        #region "Db Sets"
        public DbSet<DimEmployees> DimEmployees { get; set; }
        public DbSet<DimProducts> DimProducts { get; set; }
        public DbSet<DimCustomers> DimCustomers { get; set; }
        public DbSet<DimShippers> DimShippers { get; set; }
        public DbSet<DimCategories> DimCategories { get; set; }
        
        #endregion
    }
}
