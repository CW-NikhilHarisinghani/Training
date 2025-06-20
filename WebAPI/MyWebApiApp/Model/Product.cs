namespace Model.Product;
using Model.IProduct;
public class Product : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public Product(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public void DisplayProductDetails() {
        Console.WriteLine($"Product ID: {Id}, Name: {Name}, Price: {Price:C}");
    }
}