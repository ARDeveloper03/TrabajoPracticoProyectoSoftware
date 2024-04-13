using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Command;

public class ProductCommands : IProductCommands
{
    private readonly RetailContext __context;

    public ProductCommands(RetailContext context)
    {
        __context = context;
    }

    public async Task insertProduct(Product product)
    {
        __context.Add(product);
        await __context.SaveChangesAsync();        
    }

    public async Task removeProduct(Product product)
    {
        __context.Remove(product);
        await __context.SaveChangesAsync();
    }
}
