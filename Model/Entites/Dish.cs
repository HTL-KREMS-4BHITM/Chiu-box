using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entites;

[Table("DISHES")]
public class Dish
{
    [Column("DISH_ID"), DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public int DishId { get; set; }
    
    [Column("NAME"), MaxLength(55), Required]
    public string? Name { get; set; }
    
    [Column("PRICE"), Required] 
    public decimal Price { get; set; }
    
    [Column("DESCRIPTION"), MaxLength(255)]
    public string? Description { get; set; }
    
    [Column("ALLERGENS"), MaxLength(25)]
    public string? Allergens { get; set; }
    
    [Column("CODES"), MaxLength(7), Required]
    public string? Codes { get; set; }
    
    [Column("ISINSTOCK")]
    public bool IsInStock { get; set; }
    
    public ESupplementType Type { get; set; }
}

