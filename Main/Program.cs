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
    Cart cart = new Cart();
    Product product1 = products[5];
    Product product2 = products[7];
    Console.WriteLine("Name: " + product1.Name);
    Console.WriteLine("Name: " + product2.Name);
    cart.addProduct(product1, 1);
    cart.addProduct(product2, 1);
    PurchaseCartServices purchaseCartServices = new PurchaseCartServices(cart, commandServices, queryServices);
    
}
