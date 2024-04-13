using Domain.Entities;

namespace Application.Interfaces;

public interface IProductCommands
{
    Task insertProduct(Product product);
    Task removeProduct(Product product);
}
