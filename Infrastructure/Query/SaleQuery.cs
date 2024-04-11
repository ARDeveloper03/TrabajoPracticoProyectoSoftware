using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Query;

public class SaleQuery : ISaleQuery
{
    private readonly RetailContext __context;

    public SaleQuery(RetailContext context)
    {
        __context = context;
    }

    public List<Sale> GetListSales()
    {
        var sales = __context.Sales
                    .ToList();
        return sales;
    }

    public Sale GetSale(int saleId)
    {
        var sales = __context.Sales
                    .FirstOrDefault(s => s.SaleId == saleId);
        return sales;
    }
}
