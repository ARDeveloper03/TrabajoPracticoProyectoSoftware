using Domain.Entities;

namespace Application.Interfaces;

public interface ISaleServices
{
    Task CreateSale(Sale sale);
    Task DeleteSale(Sale sale);
    Task<List<Sale>> GetAll();
    Task<Sale> GetById(int saleId);
}
