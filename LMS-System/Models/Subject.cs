using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_System.Models
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        public string? SubjectId { get; set; }
        [Required]
        public string? SubjectName { get; set; }
        public string? Description { get; set; }
        public int NumOfCourse { get; set; } 
    }
}
