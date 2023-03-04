using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using MultipleTenancyTest.Data;
using MultipleTenancyTest.Entities;
using MultipleTenancyTest.Service;

namespace MultipleTenancyTest.Pages
{
    public class ProductModel : PageModel
    {
        private readonly TenantDataBaseContext _adminContext;
        private readonly IMemoryCache _cache;
        public ProductModel(TenantDataBaseContext adminContext, IMemoryCache cache)
        {
            _adminContext = adminContext;
            _cache = cache;
        }
        public string TenantName { get; set; }
        [BindProperty]
        public string ProductName { get; set; }
        public List<Product> ListProduct { get; set; }
        public void OnGet()
        {
            if (_cache.TryGetValue<string>("TenantName", out string a))
                TenantName = _cache.Get<string>("TenantName");
        }

        public void OnPost()
        {
            var tenantId = _cache.Get<int>("TenantId");
            var productService = new ProductService(tenantId, _adminContext);
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = ProductName,
                Note = $"Sản phẩm của tenant {TenantName}"
            };

            productService.CreateProduct(product);
        }
    }
}
