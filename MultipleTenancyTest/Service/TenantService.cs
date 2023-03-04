using MultipleTenancyTest.Data;
using MultipleTenancyTest.Entities;

namespace MultipleTenancyTest.Service
{
    public class TenantService : ITenantService
    {
        private TenantDataBaseContext _tenantAdmin;
        public TenantService(TenantDataBaseContext tenantAdmin)
        {
            _tenantAdmin = tenantAdmin;
        }
        public Tenant CreateTenant(string TenantName)
        {
            var tentant = new Tenant()
            {
                Name = TenantName,
            }; 
            
            _tenantAdmin.Tenants.Add(tentant);
            _tenantAdmin.SaveChanges();

            InitTenant(tentant.Id);

            return tentant;
        }

        private void InitTenant(int IdTenant)
        {
            var tenant = _tenantAdmin.Tenants.Find(IdTenant);

            if (tenant != null)
            {
                using (var tentantContext = new TenantContext(tenant))
                {
                    tentantContext.Database.EnsureCreated();
                }
            }
        }
    }
}
