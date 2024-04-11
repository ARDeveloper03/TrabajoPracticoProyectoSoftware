using Domain.Entities;

namespace Application;

public interface ICategoryServices
{
    Task CreateCategory(Category category);
    Task DeleteCategory(Category category);
    Task<List<Category>> GetAll();
    Task<Category> GetById(int categoryId);
}
