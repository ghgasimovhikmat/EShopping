namespace Basket.Entity;

public class ShoppingCart
{
    public string UserName { get; set; }
    public List<ShoppingCartItem> Items = new List<ShoppingCartItem>();
    
    public ShoppingCart()
    {
        
    }

    public ShoppingCart(string userName)
    {
        UserName = userName;
    }
}