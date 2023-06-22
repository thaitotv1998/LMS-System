using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_System.Models
{
    [Table("Resource")]
    public class Resource
    {
        [Key]
        public Guid ResId { get; set; }
        public string? FilePath { get; set; }
        public Guid TopicId { get; set; }

        [ForeignKey("TopicId")]
        public Topic? Topic { get; set; }
    }
}
