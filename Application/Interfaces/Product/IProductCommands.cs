using Domain.Entities;

namespace Application.Interfaces;

public interface IProductCommands
{
    Task InsertProduct(Product product);
    Task RemoveProduct(Product product);
}
