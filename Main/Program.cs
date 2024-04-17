//Implement dependency injection
using Application.Interfaces;
using Application.Screens;
using Application.UseCase;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Command;
using Infrastructure.Persistence;
using Infrastructure.Query;

using (var context = new RetailContext()){
    context.Database.EnsureCreated();
    CategoryCommands commands = new CategoryCommands(context);
    CategoryQuery query = new CategoryQuery(context);
    ProductCommands productCommands = new ProductCommands(context);
    ProductQuery productQuery = new ProductQuery(context);
    SaleCommands saleCommands = new SaleCommands(context);
    SaleQuery saleQuery = new SaleQuery(context);
    SaleProductCommands saleProductCommands = new SaleProductCommands(context);
    SaleProductQuery saleProductQuery = new SaleProductQuery(context);
    CategoryServices categoryServices = new CategoryServices(commands, query);
    ProductServices productServices = new ProductServices(productCommands, productQuery);
    SaleServices saleServices = new SaleServices(saleCommands, saleQuery);
    SaleProductServices saleProductServices = new SaleProductServices(saleProductCommands, saleProductQuery);
    CommandServices commandServices = new CommandServices(categoryServices, productServices, saleServices, saleProductServices);

    QueryServices queryServices = new QueryServices(categoryServices, productServices, saleServices, saleProductServices);
    List<Product> products = await queryServices.getProducts();
    List<Category> categories = await queryServices.getCategories();
    Cart cart = new Cart();
    Product product1 = products[5];
    Product product2 = products[7];
    Product product3 = products[6];
    Product product4 = products[8];
    Product product5 = products[12];
    Product product6 = products[11];
    Product product7 = products[10];
    Product product8 = products[3];
    Product product9 = products[1];
    Product product10 = products[29];
    Product product11 = products[23];
    // cart.addProduct(product1, 324);
    // cart.addProduct(product2, 754);
    // cart.addProduct(product3, 3244);
    // cart.addProduct(product4, 72);
    // cart.addProduct(product5, 54);
    // cart.addProduct(product6, 334);
    // cart.addProduct(product7, 735);
    // cart.addProduct(product8, 854);
    // cart.addProduct(product9, 1111);
    // cart.addProduct(product10, 222);
    // cart.addProduct(product11, 333);
    PurchaseCartServices purchaseCartServices = new PurchaseCartServices(cart, commandServices, queryServices);

    //Testing MAINMENU
    CartMenu cartMenu = new CartMenu(cart ,purchaseCartServices);
    ListingMenu listingMenu = new ListingMenu(cart, products, categories);
    MainMenu mainMenu = new MainMenu(cartMenu, listingMenu);
    // cartMenu.drawScreen();
    mainMenu.drawScreen();
    // foreach(Product product in products){
    //     Console.WriteLine("A category");
    //     Console.WriteLine(product.Category);
    // }

}
