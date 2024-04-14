using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCase;

public class PurchaseCartServices : IPurchaseCartServices
{
    private readonly Cart __cart;
    private readonly ICommandServices __commandServices;
    private List<Product> products;
    private Dictionary<Product, int> quantities;
    private Sale currentSale;
    private decimal subTotal;
    private decimal total;
    private decimal totalDiscount;
    private decimal taxes = (decimal)1.21;
    public PurchaseCartServices(Cart cart, ICommandServices commandServices)
    {
        __cart = cart;
        __commandServices = commandServices;
    }

    private void computeSubTotal(){
        foreach(Product element in products){
            decimal unitPrice = element.Price;
            int amount = quantities[element];
            subTotal += amount*unitPrice;
        }
    }
    private void computeTotalDiscount(){
        foreach(Product element in products){
            decimal unitDiscount = element.Discount;
            int amount = quantities[element];
            totalDiscount = amount*unitDiscount;
        }
    }
    private void computeTotal(){
        total = (subTotal - totalDiscount) * taxes;
    }
    private void createSale(){
        currentSale = new Sale(total, subTotal, totalDiscount, taxes, DateTime.Today);
        __commandServices.insertSale(currentSale);
    }
    private void createSaleProducts(){
        int currentSaleFK = currentSale.SaleId;
        Guid currentProductFK;
        int currentQuantity;
        foreach(Product element in products){
            currentQuantity = quantities[element];
            currentProductFK = element.ProductId;
            SaleProduct currentSaleProduct = new SaleProduct{
                ProductId = currentProductFK, 
                SaleId = currentSaleFK, 
                Quantity = currentQuantity, 
                Price = element.Price,
                Discount = element.Discount
                };
            __commandServices.insertSaleProduct(currentSaleProduct);
        }
    }
    private void resetServices(){
        products = new List<Product>();
        quantities = new Dictionary<Product, int>();        
        subTotal = 0;
        total = 0;
        totalDiscount = 0;
    }
    public void purchaseCart()
    {
        computeSubTotal();
        computeTotalDiscount();
        computeTotal();
        createSale();
        createSaleProducts();
        resetServices();
    }
}
