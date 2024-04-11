using Domain.Entities;

namespace Application.Interfaces;

public interface ICategoryCommands
{
    Task InsertCategory(Category category);
    Task RemoveCategory(Category category);
}
