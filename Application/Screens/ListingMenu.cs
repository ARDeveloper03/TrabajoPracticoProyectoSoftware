using Application.Interfaces;
using Domain.Entities;

namespace Application.Screens;

public class ListingMenu : IScreen
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
                    break;
                case "1":
                    drawAddingItemToCartBox();
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
                    if(currentPage < (products.Count / 10)){
                        currentPage += 1;
                        Console.WriteLine("NEW PAGE");
                        drawTopSection();
                        drawMiddleSection();
                        drawBottomSection();
                    }
                    break;
                case "4":
                    drawProductDetailScreen();
                    drawTopSection();
                    drawMiddleSection();
                    drawBottomSection();
                    break;
            }
            if(input == "5"){
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
        int lowerIndex = currentPage * 10;
        int upperIndex = lowerIndex + 10;
        if(upperIndex > products.Count - 1){
            upperIndex = products.Count - 1;
        }
        for(int i = lowerIndex; i < upperIndex; i++){
            Product currentProduct = products[i];
            string categoryName = "";
            foreach(Category category in categories){
                if(category.CategoryId == currentProduct.CategoryId){
                    categoryName = category.Name;
                }
            }
            List<string> data = new List<string>{$"| {i + 1}", currentProduct.Name, categoryName, currentProduct.Discount.ToString(), currentProduct.Price.ToString()};
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
    public void drawAddingItemToCartBox(){

        Console.WriteLine(dash);
        Console.WriteLine("Ingresa el ID del producto a agregar en el carrito: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese la cantidad de productos a agregar en el carrito: ");
        int quantity = int.Parse(Console.ReadLine());
        if(products.Count > id){
            Product addedProduct = products[id - 1];
            cart.addProduct(addedProduct, quantity);
        }
    }
    public void seeProduct(){

        Console.WriteLine(dash);
        Console.WriteLine("Ingresa el ID del producto a ver: ");
        int id = int.Parse(Console.ReadLine());
    }
    public void drawProductDetailScreen()
    {
        Console.WriteLine(dash);
        Console.WriteLine("Ingrese el ID del producto: ");
        Console.WriteLine(dash);
        int id = int.Parse(Console.ReadLine());
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
        Console.WriteLine("|Descuento: " + product.Discount + " |");
        Console.WriteLine("|Precio: " + product.Price + " |");
        Console.WriteLine("|Descripcion: " + product.Description + " |");
        Console.WriteLine(dash);
        Console.WriteLine("Presione cualquier tecla para volver al listado: ");
        Console.ReadLine();
    }
}
