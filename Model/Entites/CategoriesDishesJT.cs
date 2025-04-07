using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entites;
[Table("CATEGORIES_DISHES_JT")]
public class CategoriesDishesJT
{
    [Column("CATEGORIES_ID")]
    public int CategoryId { get; set; }
    
    public Category Category { get; set; }
    
    [Column("DISH_ID")]
    public int DishId { get; set; }
    
    public Dish Dish { get; set; }
}