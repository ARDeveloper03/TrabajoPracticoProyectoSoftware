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
    public Task<List<Category>> getCategories()
    {
        return __categoryServices.getAll();
    }

    public Task<List<Product>> getProducts()
    {
        return __productServices.getAll();
    }

    public Task<List<Sale>> getSales()
    {
        return __saleServices.getAll();
    }
    //Get by id
    public Task<Category> getCategoryById(int id)
    {
        return __categoryServices.getById(id);
    }
    public Task<Product> getProductById(Guid id)
    {
        return __productServices.getById(id);
    }
    public Task<Sale> getSaleById(int id)
    {
        return __saleServices.getById(id);
    }
}
