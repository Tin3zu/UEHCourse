using System;
using System.Collections.Generic;

namespace UEHCourse.Models
{
    public partial class Field
    {
        public Field()
        {
            Courses = new HashSet<Course>();
        }

        public int FieldId { get; set; }
        public string? FieldName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
