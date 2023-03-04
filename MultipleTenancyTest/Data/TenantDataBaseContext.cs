using Microsoft.EntityFrameworkCore;
using MultipleTenancyTest.Entities;

namespace MultipleTenancyTest.Data
{
    public class TenantDataBaseContext : DbContext
    {
        public DbSet<Tenant> Tenants { get; set; }
        public TenantDataBaseContext(DbContextOptions<TenantDataBaseContext> options) : base(options)
        {
            
        }
    }
}
