using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MultipleTenancyTest.Entities;
using MultipleTenancyTest.Service;

namespace MultipleTenancyTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITenantService _tenantService;
        [BindProperty]
        public Tenant tenant { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ITenantService tenantService)
        {
            _logger = logger;
            _tenantService = tenantService;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            _tenantService.CreateTenant(tenant.Name);
        }
    }
}