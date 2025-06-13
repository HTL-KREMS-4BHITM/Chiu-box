using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entites;
[Table("ALLERGENS")]
public class Allergens
{
    [Column("ALLERGENS_ID"), MaxLength(25)]
    public int? AllergensId { get; set; }
    
    [Column("ALLERGENSTYPE"), MaxLength(25)]
    public string? AllergenType { get; set; }
    
    [Column("ALLERGENCHAR"), MaxLength(25)]
    public string? AllergenChar { get; set; }
    
}