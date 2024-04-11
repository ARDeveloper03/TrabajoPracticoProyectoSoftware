using Domain.Entities;

namespace Application.Interfaces;

public interface ISaleProductQuery
{
    List<SaleProduct> GetListSaleProducts();
    SaleProduct GetSaleProduct(int shoppingCartId);
}
