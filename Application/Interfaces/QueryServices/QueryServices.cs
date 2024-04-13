using Domain.Entities;

namespace Application.UseCase;

public interface IQueryServices
{
    Task<List<Category>> getCategories();
    Task<List<Product>> getProducts();
    Task<List<Sale>> getSales();
    Task<Category> getCategoryById(int id);
    Task<Product> getProductById(Guid id);
    Task<Sale> getSaleById(int id);
}
