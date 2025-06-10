using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entites;
[Table("DISHES_ORDERS_JT")]
public class DishesOrderJT
{
    [Column("ORDER_ID")]
    public int OrderId { get; set; }
    [Column("DISH_ID")]
    public int DishId { get; set; }
    [Column("DISH_QUANTITY")]
    public int DishQuantity { get; set; }
}