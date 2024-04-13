namespace Application.Interfaces;

public interface IPurchaseCartServices
{
    public void purchaseCart(ICart cart, ICommandServices commandServices);
}
