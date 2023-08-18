using System.ComponentModel.DataAnnotations;

namespace EticaretWeb.Data;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }
    
    public List<Product>? Products { get; set; }
}