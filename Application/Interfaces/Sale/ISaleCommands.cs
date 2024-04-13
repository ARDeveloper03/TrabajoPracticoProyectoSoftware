using Domain.Entities;

namespace Application.Interfaces;

public interface ISaleCommands
{
    Task insertSale(Sale sale);
    Task removeSale(Sale sale);
}
