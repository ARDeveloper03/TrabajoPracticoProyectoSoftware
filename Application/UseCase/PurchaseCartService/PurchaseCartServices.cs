using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCase;

public class PurchaseCartServices : IPurchaseCartServices
{
    private readonly Cart __cart;
    private readonly ICommandServices __commandServices;
    private readonly IQueryServices __queryServices;
    private List<Product> products;
    private Dictionary<Product, int> quantities;
    private List<SaleProduct> saleProducts;
    private Sale currentSale;
    private decimal subTotal;
    private decimal total;
    private decimal totalDiscount;
    private decimal taxes = (decimal)1.21;
    public PurchaseCartServices(Cart cart, ICommandServices commandServices, IQueryServices queryServices)
    {
        products = new List<Product>();
        quantities = new Dictionary<Product, int>();
        saleProducts = new List<SaleProduct>();
        __cart = cart;
        __commandServices = commandServices;
        __queryServices = queryServices;
    }
    public void retrieveProducts(){
        quantities = __cart.popQuantities();
        products = __cart.popProducts();
    }

    public void computeSubTotal(){
        foreach(Product element in products){
            decimal unitPrice = element.Price;
            int amount = quantities[element];
            subTotal += amount*unitPrice;
        }
    }
    public void computeTotalDiscount(){
        foreach(Product element in products){
            decimal unitDiscount = element.Discount;
            int amount = quantities[element];
            totalDiscount = amount*unitDiscount;
        }
    }
    public void computeTotal(){
        total = (subTotal - totalDiscount) * taxes;
    }
    public async Task insertSale(){
        currentSale = new Sale(total, subTotal, totalDiscount, taxes, DateTime.Now);
        await __commandServices.insertSale(currentSale);
    }
    public async Task startPurchasingCart(){
        retrieveProducts();
        computeSubTotal();
        computeTotalDiscount();
        computeTotal();
        await insertSale();
    }
    public void createSaleProducts(){
        foreach(Product element in products){
            SaleProduct currentSaleProduct = new SaleProduct{ProductId = element.ProductId, SaleId = currentSale.SaleId, Quantity = quantities[element], Price = element.Price, Discount = element.Discount};
            saleProducts.Add(currentSaleProduct);
        }
    }
    public async Task insertSaleProducts(){
        foreach(SaleProduct element in saleProducts){
            await insertion(element);
        }
    }
    public async Task insertion(SaleProduct saleProduct){
        await __commandServices.insertSaleProduct(saleProduct);
    }
    public void resetServices(){
        products = new List<Product>();
        quantities = new Dictionary<Product, int>();        
        subTotal = 0;
        total = 0;
        totalDiscount = 0;
    }
    public async Task finishPurchasingCart(){
        createSaleProducts();
        await insertSaleProducts();
    }
}
