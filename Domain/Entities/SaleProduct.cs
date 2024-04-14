namespace Domain.Entities;

public class SaleProduct
{
    public SaleProduct()
    {
    }

    public SaleProduct(Guid productId, int saleId, int quantity, decimal price, int discount)
    {
        ProductId = productId;
        SaleId = saleId;
        Quantity = quantity;
        Price = price;
        Discount = discount;
    }
    public int ShoppingCartId {get;set;}
    public Sale Sale {get;set;}
    public int SaleId {get;set;}
    public Product Product {get;set;}
    public Guid ProductId {get;set;}
    public int Quantity {get;set;}
    public decimal Price {get;set;}
    public int Discount {get;set;}
}
