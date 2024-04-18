using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCase;

public class PurchaseCartServices : IPurchaseCartServices
{
    private readonly Cart __cart;
    private readonly ISaleServices __saleServices;
    private readonly ISaleProductServices __saleProductServices;
    private List<Product> products;
    private Dictionary<Product, int> quantities;
    private List<SaleProduct> saleProducts;
    private Sale currentSale;
    private decimal subTotal;
    private decimal total;
    private decimal totalDiscount;
    private decimal taxes = 1.21m;
    public PurchaseCartServices(Cart cart, ISaleServices saleServices, ISaleProductServices saleProductServices)
    {
        products = new List<Product>();
        quantities = new Dictionary<Product, int>();
        saleProducts = new List<SaleProduct>();
        __cart = cart;
        __saleServices = saleServices;
        __saleProductServices = saleProductServices;
        
    }
    public void retrieveProducts(){
        quantities = __cart.popQuantities();
        products = __cart.popProducts();
    }

    public void computeSubTotalAndTotalDiscount(){
        foreach(Product element in products){
            decimal percentage = element.Discount / 100m;
            decimal unitPrice = element.Price;        
            decimal unitDiscount = element.Price * percentage;    
            int amount = quantities[element];
            subTotal += amount*unitPrice;
            totalDiscount += amount*unitDiscount;
        }
    }
    public void computeTotal(){
        total = (subTotal - totalDiscount) * taxes;
    }
    public async Task insertSale(){
        currentSale = new Sale(total, subTotal, totalDiscount, taxes, DateTime.Now);
        await __saleServices.createSale(currentSale);
    }
    public async Task startPurchasingCart(){
        retrieveProducts();
        computeSubTotalAndTotalDiscount();
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
        await __saleProductServices.createSaleProduct(saleProduct);
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
