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

    public async Task CreateProduct(Product product)
    {
        await __command.InsertProduct(product);
    }

    public async Task DeleteProduct(Product product)
    {
        await __command.RemoveProduct(product);
    }

    public Task<List<Product>> GetAll()
    {
        var products = __query.GetListProducts();
        return Task.FromResult(products);
    }

    public Task<Product> GetById(Guid productId)
    {
        var products = __query.GetProduct(productId);
        return Task.FromResult(products);
    }
}
