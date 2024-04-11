using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCase;

public class SaleService : ISaleServices
{
    private readonly ISaleCommands __command;
    private readonly ISaleQuery __query;

    public SaleService(ISaleCommands command, ISaleQuery query)
    {
        __command = command;
        __query = query;
    }

    public async Task CreateSale(Sale sale)
    {
        await __command.InsertSale(sale);
    }

    public async Task DeleteSale(Sale sale)
    {
        await __command.RemoveSale(sale);
    }

    public Task<List<Sale>> GetAll()
    {
        var sales = __query.GetListSales();
        return Task.FromResult(sales);
    }

    public Task<Sale> GetById(int saleId)
    {
        var sales = __query.GetSale(saleId);
        return Task.FromResult(sales);
    }
}
