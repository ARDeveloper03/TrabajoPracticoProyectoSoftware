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
    CategoryServices categoryServices = new CategoryServices(commands, query);
    ProductServices productServices = new ProductServices(productCommands, productQuery);
    SaleServices saleServices = new SaleServices(saleCommands, saleQuery);
    QueryServices queryServices = new QueryServices(categoryServices, productServices, saleServices);
    //Testing
    // Category firstOne = new Category();
    // firstOne.CategoryId = 7;
    // firstOne.Name = "Medicine";
    // await categoryServices.CreateCategory(firstOne);
    // Category chosenOne = await categoryServices.GetById(6);
    // await categoryServices.DeleteCategory(chosenOne);
    //Testing
    var fetchedCategories = await queryServices.GetProducts();

    foreach(Product element in fetchedCategories){
    Console.WriteLine("Id: " + element.ProductId);
    Console.WriteLine("Name: " + element.Name);
    Console.WriteLine("---------------------------");
    }

}
