using Domain.Entities;

namespace Application;

public interface ICategoryServices
{
    Task createCategory(Category category);
    Task deleteCategory(Category category);
    Task<List<Category>> getAll();
    Task<Category> getById(int categoryId);
}
