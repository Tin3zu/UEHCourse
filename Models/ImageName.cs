using System;
using System.Collections.Generic;

namespace UEHCourse.Models
{
    public partial class ImageName
    {
        public int CourseId { get; set; }
        public string? ImageName1 { get; set; }

        public virtual Course? Course { get; set; }
    }
}
