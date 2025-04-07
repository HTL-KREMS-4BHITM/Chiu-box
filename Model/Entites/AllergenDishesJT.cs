using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entites;
[Table("ALLERGEN_DISHES_JT")]
public class AllergenDishesJT
{
    [Column("ALLERGENS_ID")]
    public int AllergenId { get; set; }
    
    public Allergens Allergen { get; set; }
    
    [Column("DISH_ID")]
    public int DishId { get; set; }
    
    public Dish Dish { get; set; }
}