using Application.Interfaces;
using Domain.Entities;
namespace Presentation.Views;

public class CartMenu : IView
{
    private readonly IPurchaseCartServices __purchaseService;
    private Cart cart;
    private List<Product> products;
    private Dictionary<Product, int> quantities;
    private string dash;
    private List<char> section;
    private List<string> headers;
    private List<char> newSection;
    private List<string> options;
    private List<string> options2;
    private int currentPage;

    public CartMenu(Cart cart, IPurchaseCartServices purchaseService)
    {
        this.cart = cart;
        __purchaseService = purchaseService;
        dash = new string('-', 130);
        section = new List<char>() {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'};
        headers = new List<string>{"Nombre", "Descuento Unitario", "Cantidad", "Precio Unitario", "Subtotal"};
        newSection = new List<char>(section);
        options = new List<string>{"|Opciones:", "Eliminar ultimo item: 1", "Pagina anterior: 2", "Pagina siguiente: 3", "Comprar: 4"};
        options2 = new List<string>{"|Opciones:", "Menu principal: 5", "", "", ""};
        currentPage = 0;
    }

    public async void drawScreen()
    {
        bool run = true;
        string input = "0";
        while(run){
            switch(input){
                case "0":
                    drawTopSection();
                    drawMiddleSection();
                    drawBottomSection();
                    break;
                case "1":   
                    products.RemoveAt(products.Count - 1);
                    drawTopSection();
                    drawMiddleSection();
                    drawBottomSection();
                    break;
                case "2":
                    if(currentPage > 0){
                    currentPage -= 1;
                    Console.WriteLine("NEW PAGE");
                    drawTopSection();    
                    drawMiddleSection();
                    drawBottomSection();
                    }
                    break;
                case "3":
                        if(currentPage < (products.Count/ 10)){
                        currentPage += 1;
                        Console.WriteLine("NEW PAGE");
                        drawTopSection();
                        drawMiddleSection();
                        drawBottomSection();
                    }
                    break;
                case "4":
                    var start = __purchaseService.startPurchasingCart();                    
                    Task.WaitAll(start);
                    var finish = __purchaseService.finishPurchasingCart();
                    Task.WaitAll(finish);
                    products = new List<Product>();
                    quantities = new Dictionary<Product, int>();
                    Console.WriteLine("Compra realizada con exito!");
                    Console.WriteLine("Presione cualquier tecla para continuar: ");
                    Console.ReadLine();
                    break;
            }
            if(input == "5" | input == "4"){
                break;
                }
            input = await Console.In.ReadLineAsync();
        }
    }

    public void drawTopSection(){
        Console.WriteLine(dash);
        foreach(string element in headers){
            int i = 0;
            newSection = new List<char>(section);
            foreach(char character in element){
                newSection[i] = character;
                i++;
            }
            Console.Write(string.Join("", newSection));
        }
        Console.WriteLine("");
        Console.WriteLine(dash);
        }
    public void drawMiddleSection(){
        products = cart.getProducts();
        quantities = cart.getQuantities();
        int lowerIndex = currentPage * 10;
        int upperIndex = lowerIndex + 10;
        if(upperIndex > products.Count - 1){
            upperIndex = products.Count;
        }
        for(int i = lowerIndex; i < upperIndex; i++){
            Product currentProduct = products[i];
            decimal subtotal = currentProduct.Price * quantities[currentProduct];
            List<string> data = new List<string>{currentProduct.Name, currentProduct.Discount.ToString() + "%", quantities[currentProduct].ToString(), currentProduct.Price.ToString(), subtotal.ToString()};
            foreach(string element in data){
                int it = 0;
                newSection = new List<char>(section);
                foreach(char character in element){
                    newSection[it] = character;
                    it++;
                if(it == section.Count - 1){
                    break;
                }
            }
            Console.Write(string.Join("", newSection));            
            }
            Console.WriteLine("");
        }
        Console.WriteLine(dash);
    }
    public void drawBottomSection(){
        foreach(string element in options){
            int i = 0;
            newSection = new List<char>(section);
            foreach(char character in element){
                newSection[i] = character;
                i++;
            }
            Console.Write(string.Join("", newSection));
        }
        Console.WriteLine("");
        Console.WriteLine(dash);
        foreach(string element in options2){
            int i = 0;
            newSection = new List<char>(section);
            foreach(char character in element){
                newSection[i] = character;
                i++;
            }
            Console.Write(string.Join("", newSection));
        }
        Console.WriteLine("");
        Console.WriteLine(dash);
    }
}
