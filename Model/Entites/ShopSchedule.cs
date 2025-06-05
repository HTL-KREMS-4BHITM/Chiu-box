using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entites;

public class ShopSchedule
{
    [Column("SCHEDULE_ID"), DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public int Id { get; set; }
    [Column("DAY")]
    public DayOfWeek Day { get; set; }
    [Column("StartTime")]
    public TimeSpan StartTime { get; set; }
    
    [Column("EndTime")]
    public TimeSpan EndTime { get; set; }
}
