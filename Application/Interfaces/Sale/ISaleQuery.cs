using Domain.Entities;

namespace Application.Interfaces;

public interface ISaleQuery
{
    List<Sale> GetListSales();
    Sale GetSale(int saleId);
}
