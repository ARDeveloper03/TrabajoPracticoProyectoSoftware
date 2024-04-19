using Application.Interfaces;
using Domain.Entities;
namespace Presentation.Views;
public class ListingMenu : IView
{
    private Cart cart;
    private List<Product> products;
    private List<Category> categories;
    private string dash;
    private List<char> section;
    private List<string> headers;
    private List<char> newSection;
    private List<string> options;
    private List<string> options2;
    private int currentPage;
    public ListingMenu(Cart cart, List<Product> products, List<Category> categories)
    {
        this.cart = cart;
        this.products = products;
        this.categories = categories;
        dash = new string('-', 130);
        section = new List<char>() {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|'};
        headers = new List<string>{"|ID", "Nombre", "Categoria", "Descuento", "Precio"};
        newSection = new List<char>(section);
        options = new List<string>{"|Opciones:", "Agregar al Carrito: 1", "Pagina anterior: 2", "Pagina siguiente: 3", "Ver Producto: 4"};
        options2 = new List<string>{"|Opciones:", "Menu Principal: 5", " ", " ", " "};
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
                    input = await Console.In.ReadLineAsync();
                    break;
                case "1":
                    drawAddingItemToCartBox();
                    input = "0";
                    break;
                case "2":
                    if(currentPage > 0){
                        currentPage -= 1;                        
                    }
                    input = "0";
                    break;
                case "3":
                    if(currentPage < (products.Count / 10)){
                        currentPage += 1;                        
                    }
                    input = "0";
                    break;
                case "4":
                    drawProductDetailScreen();
                    input = "0";
                    break;
            }
            if(input == "5"){
                break;
            }            
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
        int lowerIndex = currentPage * 10;
        int upperIndex = lowerIndex + 10;
        if(upperIndex > products.Count - 1){
            upperIndex = products.Count - 1;
        }
        for(int i = lowerIndex; i < upperIndex; i++){
            Product currentProduct = products[i];
            List<string> data = new List<string>{$"| {i + 1}", currentProduct.Name, currentProduct.Category.Name, currentProduct.Discount.ToString() + "%", currentProduct.Price.ToString()};
            string substring = "";
            foreach(string element in data){
                int length = element.Length;
                if(length >= 26){
                    substring += element.Substring(0, 25) + "|"; 
                }
                else{
                    string spaces = new string(' ', 25 - length);
                    substring += element + spaces + "|";
                }
            }
            Console.Write(substring);
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
    public void drawAddingItemToCartBox(){

        Console.WriteLine(dash);
        Console.WriteLine("Ingresa el ID del producto a agregar en el carrito: ");
        string IDInput = Console.ReadLine();
        int id;
        bool success = int.TryParse(IDInput, out id);
        if(success){
            if(id > 0  && id < products.Count){
                Console.WriteLine("Ingrese la cantidad de productos a agregar en el carrito: ");
                int quantity;
                string quantityInput = Console.ReadLine();
                success = int.TryParse(quantityInput, out quantity);
                if(success && quantity > 0){
                    Product addedProduct = products[id - 1];
                    cart.addProduct(addedProduct, quantity);
                    Console.WriteLine("Producto agregado con exito");
                }
                else{
                    Console.WriteLine("Cantidad erronea");
                }
            }
            else{
                Console.WriteLine("Id invalido");
            }
        }
        else{
            Console.WriteLine("Id invalido");
        }

        Console.WriteLine("Presione cualquier tecla para continuar");
        Console.ReadLine();
    }

    public void drawProductDetailScreen()
    {
        Console.WriteLine(dash);
        Console.WriteLine("Ingrese el ID del producto: ");
        Console.WriteLine(dash);
        int id;
        string IDInput = Console.ReadLine();
        bool success = int.TryParse(IDInput, out id);
        if(success && id > 0){
            Product product = products[id - 1];
            string categoryName = "";
            foreach(Category element in categories){
                if(element.CategoryId == product.CategoryId){
                    categoryName = element.Name;
                }
            }
            Console.WriteLine(dash);
            Console.WriteLine("|Nombre: " + product.Name + " |");
            Console.WriteLine("|Categoria: " + categoryName + " |");
            Console.WriteLine("|Descuento: " + product.Discount + "% |");
            Console.WriteLine("|Precio: " + product.Price + " |");
            Console.WriteLine("|Descripcion: " + product.Description + " |");
            Console.WriteLine(dash);
        }
        else{
            Console.WriteLine("Id invalido");
        }
        Console.WriteLine("Presione cualquier tecla para volver al listado: ");
        Console.ReadLine();
    }
}
