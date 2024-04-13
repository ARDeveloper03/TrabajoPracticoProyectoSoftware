using Domain.Entities;

namespace Application.Interfaces;

public interface ISaleProductCommands
{
    Task insertSaleProduct(SaleProduct saleProduct);
    Task removeSaleProduct(SaleProduct saleProduct);
}
