using Application.Interfaces;

namespace Application.Screens;

public class MainMenu : IScreen
{
    private readonly IScreen __cartMenu;
    private readonly IScreen __listingMenu;

    public MainMenu(IScreen cartMenu, IScreen listingMenu)
    {
        __cartMenu = cartMenu;
        __listingMenu = listingMenu;
    }

    public async void drawScreen()
    {
        string input = "0";        
        while(true){

            switch(input){
                case "0":
                    Console.WriteLine("Elija una opcion: ");
                    Console.WriteLine("Opcion 1: Listado de Productos");
                    Console.WriteLine("Opcion 2: Carrito de compra");
                    Console.WriteLine("Opcion 3: Salir de la aplicacion");
                    Console.WriteLine("Ingrese un numero: ");
                    break;
                case "1":
                    __listingMenu.drawScreen();
                    break;
            }
            if(input == "3"){
                Console.WriteLine("Exiting");
                break;
            }
            Task<string> buffer =  this.readInput();
            input = await buffer;
        }
    }
    public async Task<string> readInput(){
        return await Console.In.ReadLineAsync();
    }
}
