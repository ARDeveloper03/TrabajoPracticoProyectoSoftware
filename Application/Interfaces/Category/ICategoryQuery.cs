using Domain.Entities;

namespace Application.Interfaces;

public interface ICategoryQuery
{
    List<Category> GetListCategories();
    Category GetCategory(int categoryId);
}
