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

    public List<Product> getListProducts()
    {
        var products = __context.Products.ToList();
        return products;
    }

    public Product getProduct(Guid productId)
    {
        var products = __context.Products
                        .FirstOrDefault(s => s.ProductId == productId);
        return products;
    }
}
