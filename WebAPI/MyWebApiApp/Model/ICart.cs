namespace Model.ICart;
using Model.Product;
public interface ICart
{
    List<Product> GetProducts(string key);
    void AddProductToCart(string key, Product product);
    public Dictionary<string, List<Product>> Items { get; set; }

    decimal calculateTotal(string key);
}