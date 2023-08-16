namespace EticaretWeb.Models;

public class ProductModel
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
    
    public string? Image { get; set; }

    public double Price { get; set; }
    
    public int Stock { get; set; }
    
    
    public int CategoryId { get; set; }
}