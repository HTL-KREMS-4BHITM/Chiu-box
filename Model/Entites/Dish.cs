using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

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
    
    [Column("CODE"), MaxLength(7), Required]
    public string? Code { get; set; }
    
    [Column("IS_IN_STOCK")]
    public bool IsInStock { get; set; }
    
    [Column ("SUPPLEMENTTYPE"), MaxLength(10)]
    public ESupplementType Type { get; set; }
}

