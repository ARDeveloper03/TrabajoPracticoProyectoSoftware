using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Query;

public class ProductQuery : IProductQuery
{
    private readonly RetailContext __context;

    public ProductQuery(RetailContext context)
    {
        __context = context;
    }

    public List<Product> GetListProducts()
    {
        throw new NotImplementedException();
    }

    public Product GetProduct(Guid productId)
    {
        var products = __context.Products
                        .FirstOrDefault(s => s.ProductId == productId);
        return products;
    }
}
