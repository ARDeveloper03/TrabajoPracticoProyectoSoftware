using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCase;

public class SaleProductService : ISaleProductServices
{
    private readonly ISaleProductCommands __command;
    private readonly ISaleProductQuery __query;

    public SaleProductService(ISaleProductCommands command, ISaleProductQuery query)
    {
        __command = command;
        __query = query;
    }

    public async Task CreateSale(SaleProduct saleProduct)
    {
        await __command.InsertSaleProduct(saleProduct);
    }

    public async Task DeleteSale(SaleProduct saleProduct)
    {
        await __command.RemoveSaleProduct(saleProduct);
    }

    public Task<List<SaleProduct>> GetAll()
    {
        var SaleProduct = __query.GetListSaleProducts();
        return Task.FromResult(SaleProduct);
    }

    public Task<SaleProduct> GetById(int shoppingCartId)
    {
        var SaleProduct = __query.GetSaleProduct(shoppingCartId);
        return Task.FromResult(SaleProduct);
    }
}
