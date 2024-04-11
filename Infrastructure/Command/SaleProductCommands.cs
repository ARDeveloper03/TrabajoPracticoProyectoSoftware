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

    public async Task InsertSaleProduct(SaleProduct saleProduct)
    {
        __context.Add(saleProduct);
        await __context.SaveChangesAsync();
    }

    public async Task RemoveSaleProduct(SaleProduct saleProduct)
    {
        __context.Remove(saleProduct);
        await __context.SaveChangesAsync();
    }
}
