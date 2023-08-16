using System.ComponentModel.DataAnnotations;

namespace EticaretWeb.Data;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
    
    public string? Image { get; set; }

    public double Price { get; set; }
    
    public int Stock { get; set; }
    
    public bool IsApproved { get; set; }
    
    public bool IsHome { get; set; }

    public Category? Category { get; set; }
    
    public int CategoryId { get; set; }
}