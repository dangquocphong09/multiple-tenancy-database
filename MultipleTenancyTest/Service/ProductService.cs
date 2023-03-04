using MultipleTenancyTest.Data;
using MultipleTenancyTest.Entities;

namespace MultipleTenancyTest.Service
{
    public class ProductService : BaseService
    {
        public ProductService(int TenantId, TenantDataBaseContext context) : base(TenantId, context)
        {
        }

        public Product CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges(); 

            return product;
        }

        public List<Product> GetListProducts()
        {
            return _context.Products.ToList();
        }
    }
}
