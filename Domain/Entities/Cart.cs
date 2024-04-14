namespace Domain.Entities;

public class Cart 
{
    private Dictionary<Product, int> quantities;
    private List<Product> products;
    public Cart(){
        products = new List<Product>();
        quantities = new Dictionary<Product, int>();
    }
    public void addProduct(Product product, int quantity)
    {
        products.Add(product);
        quantities.Add(product, quantity);
    }
    public void removeLastProduct(){
        quantities.Remove(products[products.Count - 1]);
        products.RemoveAt(products.Count - 1);
    }
    public void removeProductByPosition(int position){
        quantities.Remove(products[position]);
        products.RemoveAt(position);
    }
    public List<Product> popProducts(){
        List<Product> poppedProducts = new List<Product>(products);
        products = new List<Product>();
        return poppedProducts;
    }
    public Dictionary<Product,int> popQuantity(){
        Dictionary<Product, int> poppedQuantities = new Dictionary<Product, int>(quantities);
        quantities = new Dictionary<Product, int>();
        return poppedQuantities;
    }
    public void disposeCart(){
        products = new List<Product>();
        quantities = new Dictionary<Product, int>();
    }
}
