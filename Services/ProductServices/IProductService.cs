using SellingProducts.Models;

namespace SellingProducts.Services.ProductServices
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
    }
}
