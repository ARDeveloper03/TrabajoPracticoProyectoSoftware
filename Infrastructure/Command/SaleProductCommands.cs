using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Command;

public class SaleProductCommands : ISaleProductCommands
{
    private readonly RetailContext __context;

    public SaleProductCommands(RetailContext context)
    {
        __context = context;
    }

    public async Task insertSaleProduct(SaleProduct saleProduct)
    {
        __context.Add(saleProduct);
        await __context.SaveChangesAsync();
    }

    public async Task removeSaleProduct(SaleProduct saleProduct)
    {
        __context.Remove(saleProduct);
        await __context.SaveChangesAsync();
    }
}
