using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCase;

public class QueryServices : IQueryServices
{
    private readonly ICategoryServices __categoryServices;
    private readonly IProductServices __productServices;
    private readonly ISaleServices __saleServices;

    public QueryServices(ICategoryServices categoryServices, IProductServices productServices, ISaleServices saleServices)
    {
        __categoryServices = categoryServices;
        __productServices = productServices;
        __saleServices = saleServices;
    }

    //Listing
    public Task<List<Category>> GetCategories()
    {
        return __categoryServices.getAll();
    }

    public Task<List<Product>> GetProducts()
    {
        return __productServices.GetAll();
    }

    public Task<List<Sale>> GetSales()
    {
        return __saleServices.getAll();
    }
    //Get by id
    public Task<Category> GetCategoryById(int id)
    {
        return __categoryServices.getById(id);
    }
    public Task<Product> GetProductById(Guid id)
    {
        return __productServices.GetById(id);
    }
    public Task<Sale> GetSaleById(int id)
    {
        return __saleServices.getById(id);
    }
}
