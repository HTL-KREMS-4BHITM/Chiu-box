using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entites;

[Table("CATEGORIES")]
public class Category
{
    [Column("CATEGORY_ID"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategoriesId { get; set; }
    
    [Column("CATEGORY_NAME"), Required, MaxLength(20)]
    public string? Name { get; set; }
    
    [Column("MAINTYPE")]
    public string? MainType{ get; set; }
}