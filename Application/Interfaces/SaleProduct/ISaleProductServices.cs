using Domain.Entities;

namespace Application.Interfaces;

public interface ISaleProductServices
{
    Task CreateSale(SaleProduct saleProduct);
    Task DeleteSale(SaleProduct saleProduct);
    Task<List<SaleProduct>> GetAll();
    Task<SaleProduct> GetById(int shoppingCartId);
}
