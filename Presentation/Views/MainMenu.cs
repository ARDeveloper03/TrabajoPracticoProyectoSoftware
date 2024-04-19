using Application.Interfaces;
namespace Presentation.Views;

public class MainMenu : IView
{
    private readonly IView __cartMenu;
    private readonly IView __listingMenu;
    private string dash = new string('-', 130);
    public MainMenu(IView cartMenu, IView listingMenu)
    {
        __cartMenu = cartMenu;
        __listingMenu = listingMenu;
    }

    public async void drawScreen()
    {
        bool run = true;
        string input = "0";        
        while(run){

            switch(input){
                case "0":
                    Console.WriteLine(dash);
                    Console.WriteLine("Elija una opcion: ");
                    Console.WriteLine("Opcion 1: Listado de Productos");
                    Console.WriteLine("Opcion 2: Carrito de compra");
                    Console.WriteLine("Opcion 3: Salir de la aplicacion");
                    Console.WriteLine("Ingrese un numero: ");
                    Console.WriteLine(dash);
                    input = await Console.In.ReadLineAsync();
                    break;
                case "1":
                    __listingMenu.drawScreen();
                    input = "0";
                    break;
                case "2":
                    __cartMenu.drawScreen();
                    input = "0";
                    break;
                default:
                    input = "0";
                    break;
            }
            if(input == "3"){
                break;
            }
        
        }
    }
}
