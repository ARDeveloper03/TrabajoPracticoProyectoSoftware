using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCase;

public class CategoryServices : ICategoryServices
{
    private readonly ICategoryCommands __command;
    private readonly ICategoryQuery __query;

    public CategoryServices(ICategoryCommands command, ICategoryQuery query)
    {
        __command = command;
        __query = query;
    }

    public async Task CreateCategory(Category category)
    {
        await __command.InsertCategory(category);

    }

    public async Task DeleteCategory(Category category)
    {
        await __command.RemoveCategory(category);
        // return Task.FromResult<object>(null);
    }

    public Task<List<Category>> GetAll()
    {
        var categories = __query.GetListCategories();
        return Task.FromResult(categories);
    }

    public Task<Category> GetById(int categoryId)
    {
        var categories = __query.GetCategory(categoryId);
        return Task.FromResult(categories);
    }
}
