using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UEHCourse.Models
{
    public partial class AdminModel
    {
        [Key]
        public string AdminId { get; set; } = null!;
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
    }
}
