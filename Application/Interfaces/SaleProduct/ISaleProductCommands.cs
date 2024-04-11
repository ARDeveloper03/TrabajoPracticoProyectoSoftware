using Domain.Entities;

namespace Application.Interfaces;

public interface ISaleProductCommands
{
    Task InsertSaleProduct(SaleProduct saleProduct);
    Task RemoveSaleProduct(SaleProduct saleProduct);
}
