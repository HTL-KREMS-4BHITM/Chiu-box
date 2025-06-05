using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entites;

public class ShopSchedule
{
    [Column("SCHEDULE_ID"), DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public int Schedule_Id { get; set; }
    [Column("DAY")]
    public string Day { get; set; }
    [Column("StartTime")]
    public TimeOnly StartTime { get; set; }
    
    [Column("EndTime")]
    public TimeOnly EndTime { get; set; }
}
