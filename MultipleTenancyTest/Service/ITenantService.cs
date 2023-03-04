using MultipleTenancyTest.Entities;

namespace MultipleTenancyTest.Service
{
    public interface ITenantService
    {
        Tenant CreateTenant(string TenantName);
    }
}
