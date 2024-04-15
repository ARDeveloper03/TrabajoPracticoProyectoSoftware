using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCase;

public class CommandServices : ICommandServices
{
    private readonly ICategoryServices __categoryServices;
    private readonly IProductServices __productServices;
    private readonly ISaleServices __saleServices;
    private readonly ISaleProductServices __saleProductServices;

    public CommandServices(ICategoryServices categoryServices, IProductServices productServices, ISaleServices saleServices, ISaleProductServices saleProductServices)
    {
        __categoryServices = categoryServices;
        __productServices = productServices;
        __saleServices = saleServices;
        __saleProductServices = saleProductServices;
    }

    public void insertCategory(Category category)
    {
        __categoryServices.createCategory(category);
    }

    public void insertProduct(Product product)
    {
        __productServices.createProduct(product);
    }

    public async Task insertSale(Sale sale)
    {
        await __saleServices.createSale(sale);
    }

    public async Task insertSaleProduct(SaleProduct saleProduct)
    {
        await __saleProductServices.createSaleProduct(saleProduct);
    }

    public void removeCategory(Category category)
    {
        __categoryServices.deleteCategory(category);
    }

    public void removeProduct(Product product)
    {
        __productServices.deleteProduct(product);
    }

    public void removeSale(Sale sale)
    {
        __saleServices.deleteSale(sale);
    }

    public void removeSaleProduct(SaleProduct saleProduct)
    {
        __saleProductServices.deleteSaleProduct(saleProduct);
    }
}
