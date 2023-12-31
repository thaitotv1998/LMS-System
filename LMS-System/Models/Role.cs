﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS_System.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public Guid RoleId { get; set; }
        [Required]
        [MaxLength(255)]
        public string? RoleName { get; set; }
    }
}
