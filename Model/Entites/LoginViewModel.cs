using System.ComponentModel.DataAnnotations;

namespace Model.Entites;

public class LoginViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
    public string? Username { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}