//Implement dependency injection
using Application.Interfaces;
using Application.UseCase;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Command;
using Infrastructure.Persistence;
using Infrastructure.Query;
using Presentation.Views;

using (var context = new RetailContext()){
    context.Database.EnsureCreated();
    //CQRS
    CategoryCommands commands = new CategoryCommands(context);
    CategoryQuery query = new CategoryQuery(context);
    ProductCommands productCommands = new ProductCommands(context);
    ProductQuery productQuery = new ProductQuery(context);
    SaleCommands saleCommands = new SaleCommands(context);
    SaleQuery saleQuery = new SaleQuery(context);
    SaleProductCommands saleProductCommands = new SaleProductCommands(context);
    SaleProductQuery saleProductQuery = new SaleProductQuery(context);

    //Services
    CategoryServices categoryServices = new CategoryServices(commands, query);
    ProductServices productServices = new ProductServices(productCommands, productQuery);
    SaleServices saleServices = new SaleServices(saleCommands, saleQuery);
    SaleProductServices saleProductServices = new SaleProductServices(saleProductCommands, saleProductQuery);
    Cart cart = new Cart();
    PurchaseCartServices purchaseCartServices = new PurchaseCartServices(cart, saleServices, saleProductServices);

    //Menus
    List<Product> products = await productServices.getAll();
    List<Category> categories = await categoryServices.getAll();
    CartMenu cartMenu = new CartMenu(cart ,purchaseCartServices);
    ListingMenu listingMenu = new ListingMenu(cart, products, categories);
    MainMenu mainMenu = new MainMenu(cartMenu, listingMenu);
    mainMenu.drawScreen();
}
