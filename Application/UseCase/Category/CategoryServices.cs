﻿using Application.Interfaces;
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

    public async Task createCategory(Category category)
    {
        await __command.insertCategory(category);

    }

    public async Task deleteCategory(Category category)
    {
        await __command.removeCategory(category);
        // return Task.FromResult<object>(null);
    }

    public Task<List<Category>> getAll()
    {
        var categories = __query.getListCategories();
        return Task.FromResult(categories);
    }

    public Task<Category> getById(int categoryId)
    {
        var categories = __query.getCategory(categoryId);
        return Task.FromResult(categories);
    }
}
