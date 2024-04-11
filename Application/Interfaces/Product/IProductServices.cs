using Domain.Entities;

namespace Application.Interfaces;

public interface IProductServices
{
    Task CreateProduct(Product product);
    Task DeleteProduct(Product product);
    Task<List<Product>> GetAll();
    Task<Product> GetById(Guid productId);

}
