using System.ComponentModel.DataAnnotations;

namespace EFMDS.Web.ViewModels;

public class RegisterViewModel
{
    [Required]
    public string FullName { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    [StringLength(100, MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "الباسورد غير متطابق")]
    public string ConfirmPassword { get; set; } = string.Empty;
    public string? Phone { get; set; }
}