using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_System.Models
{
    [Table("Topic")]
    public class Topic
    {
        public Guid TopicId { get; set; }
        public string? TopicName { get; set; }
        public Guid DocId { get; set; }

        [ForeignKey("DocId")]
        public Document? Document { get; set; }
    }
}
