//Implement dependency injection
using Application.Interfaces;
using Application.UseCase;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Command;
using Infrastructure.Persistence;
using Infrastructure.Query;

using (var context = new RetailContext()){
    context.Database.EnsureCreated();
    // CategoryCommands commands = new CategoryCommands(context);
    // CategoryQuery query = new CategoryQuery(context);
    // CategoryServices categoryServices = new CategoryServices(commands, query);
    // Category firstOne = new Category();
    // firstOne.CategoryId = 7;
    // firstOne.Name = "Medicine";
    // await categoryServices.CreateCategory(firstOne);
    // Category chosenOne = await categoryServices.GetById(6);
    // await categoryServices.DeleteCategory(chosenOne);
    // var fetchedCategories = await categoryServices.GetAll();

    // foreach(Category element in fetchedCategories){
    // Console.WriteLine("Id: " + element.CategoryId);
    // Console.WriteLine("Name: " + element.Name);
    // Console.WriteLine("---------------------------");
    // }


}
