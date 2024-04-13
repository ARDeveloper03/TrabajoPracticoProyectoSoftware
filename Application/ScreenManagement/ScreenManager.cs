using Application.Interfaces;

namespace Application;

public class ScreenManager
{
    private IScreen MainMenu;
    private IScreen ListingMenu;
    private IScreen Cart;
    private IScreen CurrentScreen;

    public ScreenManager(IScreen mainMenu, IScreen listingMenu, IScreen cart)
    {
        MainMenu = mainMenu;
        ListingMenu = listingMenu;
        Cart = cart;
        CurrentScreen = mainMenu;
    }
    public void startConsole(){
        CurrentScreen.drawScreen();
    }
    public void readInput(ConsoleKeyInfo input){
        CurrentScreen.readInput(input);
    }
    public void changeScreen(int option){
        switch(option){
            case 1:
                CurrentScreen = MainMenu;
                break;
            case 2:
                CurrentScreen = ListingMenu;
                break;
            case 3:
                CurrentScreen = Cart;
                break;
        }
    }
}
