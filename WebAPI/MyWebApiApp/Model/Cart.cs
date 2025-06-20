namespace Model.Cart;
using Model.Product;
using Model.ICart;
public class Cart : ICart
{
    public Dictionary<string, List<Product>> Items { get; set; }

    public Cart()
    {
        Items = new Dictionary<string, List<Product>>();
    }

    public List<Product> GetProducts(string key)
    {
        if (Items != null && Items.ContainsKey(key))
        {
            return Items[key];
        }
        return new List<Product>();
    }

    public void addProduct(string key, Product product)
    {
        if (Items.ContainsKey(key))
        {
            Items[key].Add(product);
        }
        else
        {
            Items[key] = new List<Product> { product };
        }
    }

    public void AddProductToCart(string key, Product product)
    {
        addProduct(key, product);
    }
    
    public decimal calculateTotal(string key)
    {
        if (Items.ContainsKey(key))
        {
            decimal total = 0;
            foreach (var product in Items[key])
            {
                total += product.Price;
            }
            return total;
        }
        return 0;
    }

}