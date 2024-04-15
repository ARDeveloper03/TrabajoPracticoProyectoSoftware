using Domain.Entities;

namespace Application.UseCase;

public interface IQueryServices
{
    Task<List<Category>> getCategories();
    Task<List<Product>> getProducts();
    Task<List<Sale>> getSales();
    Task<List<SaleProduct>> getSaleProducts();
    Task<Category> getCategoryById(int id);
    Task<Product> getProductById(Guid id);
    Task<Sale> getSaleById(int id);
    Task<SaleProduct> getSaleProductById (int id);

}
