using Domain.Entities;

namespace Application.UseCase;

public interface IQueryServices
{
    Task<List<Category>> GetCategories();
    Task<List<Product>> GetProducts();
    Task<List<Sale>> GetSales();
    Task<Category> GetCategoryById(int id);
    Task<Product> GetProductById(Guid id);
    Task<Sale> GetSaleById(int id);
}
