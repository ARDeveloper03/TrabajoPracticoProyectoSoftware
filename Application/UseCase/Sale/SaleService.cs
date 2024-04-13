using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCase;

public class SaleServices : ISaleServices
{
    private readonly ISaleCommands __command;
    private readonly ISaleQuery __query;

    public SaleServices(ISaleCommands command, ISaleQuery query)
    {
        __command = command;
        __query = query;
    }

    public async Task createSale(Sale sale)
    {
        await __command.insertSale(sale);
    }

    public async Task deleteSale(Sale sale)
    {
        await __command.removeSale(sale);
    }

    public Task<List<Sale>> getAll()
    {
        var sales = __query.getListSales();
        return Task.FromResult(sales);
    }

    public Task<Sale> getById(int saleId)
    {
        var sales = __query.getSale(saleId);
        return Task.FromResult(sales);
    }
}
