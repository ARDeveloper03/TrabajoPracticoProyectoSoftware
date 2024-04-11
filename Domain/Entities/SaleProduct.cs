namespace Domain.Entities;

public class SaleProduct
{
    public SaleProduct()
    {
    }

    public SaleProduct(int quantity, decimal price, int discount)
    {
        Quantity = quantity;
        Price = price;
        Discount = discount;
    }
    public int ShoppingCartId {get;set;}
    public Sale Sale {get;set;}
    public Product Product {get;set;}
    public int Quantity {get;set;}
    public decimal Price {get;set;}
    public int Discount {get;set;}
}
