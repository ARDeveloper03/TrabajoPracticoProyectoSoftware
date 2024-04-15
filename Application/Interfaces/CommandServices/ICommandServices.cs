using Domain.Entities;

namespace Application.Interfaces;

public interface ICommandServices
{
    public void insertProduct(Product product);
    public void removeProduct(Product product);
    public void insertCategory(Category category);
    public void removeCategory(Category category);
    public Task insertSale(Sale sale);
    public void removeSale(Sale sale);
    public Task insertSaleProduct(SaleProduct saleProduct);
    public void removeSaleProduct(SaleProduct saleProduct);
}
