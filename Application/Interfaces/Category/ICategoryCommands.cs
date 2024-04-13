using Domain.Entities;

namespace Application.Interfaces;

public interface ICategoryCommands
{
    Task insertCategory(Category category);
    Task removeCategory(Category category);
}
