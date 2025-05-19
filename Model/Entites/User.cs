using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entites;

[Table("USERS")]
public class User
{
    [Column("USER_ID"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }
    [Column("USERNAME")]
    public string? Username { get; set; }
    [Column("PASSWORD_HASH"), Required, MaxLength(100)]
    public string? PasswordHash { get; set; }
    
}