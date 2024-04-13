using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Command;

public class CategoryCommands : ICategoryCommands
{
    private readonly RetailContext __context;

    public CategoryCommands(RetailContext context)
    {
        __context = context;
    }

    public async Task insertCategory(Category category)
    {
        __context.Add(category);
        await __context.SaveChangesAsync();
    }

    public async Task removeCategory(Category category)
    {
        __context.Remove(category);
        await __context.SaveChangesAsync();
    }
}
