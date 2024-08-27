using SellingProducts.Models;
using SellingProducts.Repository.Base;

namespace SellingProducts.Services.ProductServices
{
    public class ProductService:IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;

        public ProductService(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            var products = _productRepository.GetAllIncludes(x=>x.Category);
            return products;
        }
    }
}
