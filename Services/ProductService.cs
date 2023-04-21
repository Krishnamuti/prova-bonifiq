using ProvaPub.Models;
using ProvaPub.Repository.Interfaces;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductList ListProducts(int page)
        {
            var pList = new ProductList();
            pList.Products = _productRepository.GetPaginate(page, pList.TotalCount).ToList();
            return pList;
        }

    }
}
