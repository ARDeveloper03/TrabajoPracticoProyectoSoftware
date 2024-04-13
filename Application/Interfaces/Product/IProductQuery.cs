using Domain.Entities;

namespace Application.Interfaces;

public interface IProductQuery
{
    List<Product> getListProducts();
    Product getProduct(Guid productId);
}
