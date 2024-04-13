using Domain.Entities;

namespace Application.Interfaces;

public interface ISaleProductQuery
{
    List<SaleProduct> getListSaleProducts();
    SaleProduct getSaleProduct(int shoppingCartId);
}
