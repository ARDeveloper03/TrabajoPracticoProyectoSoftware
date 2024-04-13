using Domain.Entities;

namespace Application.Interfaces;

public interface ISaleProductServices
{
    Task createSale(SaleProduct saleProduct);
    Task deleteSale(SaleProduct saleProduct);
    Task<List<SaleProduct>> getAll();
    Task<SaleProduct> getById(int shoppingCartId);
}
