using Domain.Entities;

namespace Application.Interfaces;

public interface ICategoryQuery
{
    List<Category> getListCategories();
    Category getCategory(int categoryId);
}
