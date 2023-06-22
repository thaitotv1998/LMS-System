using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_System.Models
{
    [Table("Class")]
    public class Class
    {
        [Key]
        public string ClassId { get; set; }
        [Required]
        [MaxLength(7)]
        public string? ClassName { get; set; }
        public DateTime SchoolYear { get; set; }

    }
}
