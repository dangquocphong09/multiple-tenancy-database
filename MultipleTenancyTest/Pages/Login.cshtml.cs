using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using MultipleTenancyTest.Data;
using MultipleTenancyTest.Entities;

namespace MultipleTenancyTest.Pages
{
    public class LoginModel : PageModel
    {
        private readonly TenantDataBaseContext _adminContext;
        private readonly IMemoryCache _cache;
        public LoginModel(TenantDataBaseContext adminContext, IMemoryCache cache)
        {
            _adminContext = adminContext;
            _cache = cache;
        }
        [BindProperty]
        public string teantName { get; set; }
        public string tenantLogin { get; set; } = "";
        public void OnGet()
        {
            if(_cache.TryGetValue<string>("TenantName", out string a))
                tenantLogin = _cache.Get<string>("TenantName");
        }

        public void OnPost()
        {
            var tenantDB = _adminContext.Tenants.FirstOrDefault(x => x.Name.Trim().ToLower() == teantName.Trim().ToLower());
            if (tenantDB != null)
            {
                _cache.Set("TenantId", tenantDB.Id);
                _cache.Set("TenantName", tenantDB.Name);
                tenantLogin = tenantDB.Name;
            }    
        }

        public void OnGetLogOut()
        {
            _cache.Remove("TenantId");
            _cache.Remove("TenantName");
            tenantLogin = "";
        }
    }
}
