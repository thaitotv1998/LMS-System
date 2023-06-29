using System.ComponentModel.DataAnnotations;

namespace LMS_System.ViewModels
{
    public class UserLoginDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string? Email { get; set; }
        [Required]
        [MinLength(8), MaxLength(20)]
        public string? Password { get; set; }
        public string? RoleName { get; set; }
    }
}
