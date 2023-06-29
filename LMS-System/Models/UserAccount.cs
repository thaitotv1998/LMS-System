using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_System.Models
{
    [Table("UserAccount")]
    public class UserAccount
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Username { get; set; }
        [Required]
        [Range(8,20)]
        public string? Password { get; set; }
        [EmailAddress(ErrorMessage ="Invalid email")]
        public string? Email { get; set; }
        [Phone]
        public string? Phone { get; set; }
        [DefaultValue(true)]
        public bool Gender { get; set; }
        public string? Address { get; set; }
        [DefaultValue(false)]
        public bool IsActivated { get; set; } = false;
        public Guid RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role? Role { get; set; }
    }
}
