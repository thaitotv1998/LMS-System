using System.ComponentModel.DataAnnotations;

namespace LMS_System.ViewModels
{
    public class UserRegisterDTO
    {
        [Required]
        [EmailAddress(ErrorMessage ="Invalid email")]
        public string? Email { get; set; }
        [Required]
        [MinLength(8), MaxLength(20)]
        public string? Password { get; set; }
        [Required]
        [MinLength(8), MaxLength(20)]
        public string? ConfirmPassword { get; set; }
    }
}
