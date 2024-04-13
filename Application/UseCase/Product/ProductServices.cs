using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCase;

public class ProductServices : IProductServices
{
    private readonly IProductCommands __command;
    private readonly IProductQuery __query;

    public ProductServices(IProductCommands command, IProductQuery query)
    {
        __command = command;
        __query = query;
    }

    public async Task createProduct(Product product)
    {
        await __command.insertProduct(product);
    }

    public async Task deleteProduct(Product product)
    {
        await __command.removeProduct(product);
    }

    public Task<List<Product>> getAll()
    {
        var products = __query.getListProducts();
        return Task.FromResult(products);
    }

    public Task<Product> getById(Guid productId)
    {
        var products = __query.getProduct(productId);
        return Task.FromResult(products);
    }
}
