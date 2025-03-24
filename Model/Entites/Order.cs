using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entites;

public class Order
{
    [Column("ORDER_ID"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }
    
    [Column("ORDER_DATE"), Required]
    public DateTime OrderDate { get; set; } = DateTime.Now;
}