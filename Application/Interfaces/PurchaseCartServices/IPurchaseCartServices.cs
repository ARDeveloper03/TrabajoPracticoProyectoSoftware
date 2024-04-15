namespace Application.Interfaces;

public interface IPurchaseCartServices
{
    public Task startPurchasingCart();
    public Task finishPurchasingCart();
}
