namespace Domain.Entities;

public class Product
{
    public Product()
    {
    }
    public Product(Guid productId,string name, string description, decimal price,int categoryId, string imageurl)
    {
        ProductId = productId;
        Name = name;
        Description = description;
        Price = price;
        CategoryId = categoryId;
        ImageUrl = imageurl;
    }

    public Guid ProductId {get;set;}
    public string Name {get;set;}
    public string Description {get;set;}
    public decimal Price {get;set;}
    public Category Category {get;set;}
    public int CategoryId {get;set;}
    public int Discount {get;set;}
    public string ImageUrl {get;set;}
}
