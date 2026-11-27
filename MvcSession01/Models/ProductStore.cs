namespace MvcSession01.Models;
public class ProductStore
{
    private readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 25000m },
        new Product { Id = 2, Name = "Phone", Price = 12000m },
        new Product { Id = 3, Name = "Headphones", Price = 1500m }
    };

    public List<Product> GetAll() => _products;

    public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
}