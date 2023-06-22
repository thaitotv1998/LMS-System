using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_System.Models
{
    [Table("Lesson")]
    public class Lesson
    {
        [Key]
        public Guid LessonId { get; set; }
        public string? Content { get; set; }
        public Guid TopicId { get; set; }

        [ForeignKey("TopicId")]
        public Topic? Topic { get; set; }
    }
}
