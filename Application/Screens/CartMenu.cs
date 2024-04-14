using Application.Interfaces;

namespace Application.Screens;

public class CartMenu : IScreen
{
    private readonly IPurchaseCartServices __purchaseService;

    public CartMenu(IPurchaseCartServices purchaseService)
    {
        __purchaseService = purchaseService;
    }

    public void drawScreen()
    {
        Console.Clear();
        throw new NotImplementedException();
    }

    public Task<string> readInput()
    {
        throw new NotImplementedException();
    }
}
