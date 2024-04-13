using Domain.Entities;

namespace Application.Interfaces;

public interface ISaleQuery
{
    List<Sale> getListSales();
    Sale getSale(int saleId);
}
