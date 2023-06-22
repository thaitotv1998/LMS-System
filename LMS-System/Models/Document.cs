using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_System.Models
{
    [Table("Document")]
    public class Document
    {
        [Key]
        public Guid DocId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool ApprovalStatus { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string? SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        public Subject? Subject { get; set; }
    }
}
