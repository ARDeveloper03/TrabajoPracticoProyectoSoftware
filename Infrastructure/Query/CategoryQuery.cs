using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Query;

public class CategoryQuery : ICategoryQuery
{
    private readonly RetailContext __context;

    public CategoryQuery(RetailContext context)
    {
        __context = context;
    }

    public Category getCategory(int categoryId)
    {
        var categories = __context.Categories.FirstOrDefault(s => s.CategoryId == categoryId);
        return categories;
    }

    public List<Category> getListCategories()
    {
        var categories = __context.Categories
                        .ToList();
        return categories;
    }
}
