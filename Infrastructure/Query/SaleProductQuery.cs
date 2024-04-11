using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure;

public class SaleProductQuery : ISaleProductQuery
{
    private readonly RetailContext __context;

    public SaleProductQuery(RetailContext context)
    {
        __context = context;
    }

    public List<SaleProduct> GetListSaleProducts()
    {
        var saleproducts = __context.SaleProducts
                            .ToList();
        return saleproducts;
    }

    public SaleProduct GetSaleProduct(int shoppingCartId)
    {
        var saleproducts = __context.SaleProducts
                            .FirstOrDefault(s => s.ShoppingCartId == shoppingCartId);
        return saleproducts;
    }
}
