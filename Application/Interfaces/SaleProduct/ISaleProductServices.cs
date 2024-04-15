using Domain.Entities;

namespace Application.Interfaces;

public interface ISaleProductServices
{
    Task createSaleProduct(SaleProduct saleProduct);
    Task deleteSaleProduct(SaleProduct saleProduct);
    Task<List<SaleProduct>> getAll();
    Task<SaleProduct> getById(int shoppingCartId);
}
