using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MultipleTenancyTest.Entities;
using MultipleTenancyTest.Model;

namespace MultipleTenancyTest.Data
{
    public class TenantContext : DbContext
    {
        private Tenant _tenant;
       // private TenantConfig _tenantConfig;
        private TenantDataBaseContext _adminContext;
        public TenantContext(TenantDataBaseContext adminContext)
        {
            _adminContext = adminContext;
        }

        //public TenantContext(IOptions<TenantConfig> tenantConfig)
        //{
        //    _tenantConfig = tenantConfig.Value;

        //}
        public TenantContext(Tenant tenant)
        {
            _tenant = tenant;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var tenantDBName = _tenant.Name;
            var connectionString = TenantConfig.TenantConnection.Replace("{tenantDBName}", tenantDBName);
            //var connectionString = $"server=210.245.85.16;port=3306;database={tenantDBName};uid=root;password=M@tkhau123@ABC;Convert Zero Datetime=True";
            optionsBuilder.UseSqlServer(connectionString, options => {
                options.EnableRetryOnFailure();
            });
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Product> Products { get; set; }
    }
}
