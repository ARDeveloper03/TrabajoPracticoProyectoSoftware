using Domain.Entities;

namespace Application.Interfaces;

public interface IProductQuery
{
    List<Product> GetListProducts();
    Product GetProduct(Guid productId);
}
