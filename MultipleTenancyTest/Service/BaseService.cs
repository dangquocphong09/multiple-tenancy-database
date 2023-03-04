using MultipleTenancyTest.Data;
using System.Linq;

namespace MultipleTenancyTest.Service
{
    public class BaseService
    {
        public TenantDataBaseContext _adminTenantContext;
        public TenantContext _context;
        public int _tenantId;

        public BaseService(int TenantId, TenantDataBaseContext context)
        {
            _tenantId = TenantId;
            _adminTenantContext= context;
            var tenant = context.Tenants.Find(TenantId);
            _context = new TenantContext(tenant);
        }
    }
}
