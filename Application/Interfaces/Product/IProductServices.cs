using Domain.Entities;

namespace Application.Interfaces;

public interface IProductServices
{
    Task createProduct(Product product);
    Task deleteProduct(Product product);
    Task<List<Product>> getAll();
    Task<Product> getById(Guid productId);

}
