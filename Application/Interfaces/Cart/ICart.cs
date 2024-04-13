using Domain.Entities;

namespace Application;

public interface ICart
{
    public void addProduct(Product product);
    public void removeLastProduct();
    public void removeProductByPosition(int position);
    
}
