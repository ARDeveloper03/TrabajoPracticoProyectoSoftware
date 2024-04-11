using Domain.Entities;

namespace Application.Interfaces;

public interface ISaleCommands
{
    Task InsertSale(Sale sale);
    Task RemoveSale(Sale sale);
}
