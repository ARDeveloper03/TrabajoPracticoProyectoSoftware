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

    public Category GetCategory(int categoryId)
    {
        var categories = __context.Categories.FirstOrDefault(s => s.CategoryId == categoryId);
        return categories;
    }

    public List<Category> GetListCategories()
    {
        var categories = __context.Categories
                        .ToList();
        return categories;
    }
}
