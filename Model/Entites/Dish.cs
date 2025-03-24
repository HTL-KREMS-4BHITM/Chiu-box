using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entites;

[Table("DISHES")]
public class Dish
{
    [Column("DISH_ID")]
    public int DishId { get; set; }
    [Column("NAME"), MaxLength(255)]
    public string Name { get; set; }
    public int idk { get; set; }
}