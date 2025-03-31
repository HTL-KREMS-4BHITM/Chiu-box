using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entites;

[Table("USERS")]
public class User
{
    [Column("USER_ID"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }
    [Column("USER_MAIL"), Required, MaxLength(320)]
    public string? Email { get; set; }
    [Column("PASSWORD_HASH"), Required, MaxLength(100)]
    public string? PasswordHash { get; set; }
    [Column("ADDRESS"), Required, MaxLength(50)]
    public string? Address { get; set; }
    [Column("ROLE"), Required] 
    public ERoles Role { get; set; }
}