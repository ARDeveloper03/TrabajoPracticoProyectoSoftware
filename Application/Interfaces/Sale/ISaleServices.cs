using Domain.Entities;

namespace Application.Interfaces;

public interface ISaleServices
{
    Task createSale(Sale sale);
    Task deleteSale(Sale sale);
    Task<List<Sale>> getAll();
    Task<Sale> getById(int saleId);
}
