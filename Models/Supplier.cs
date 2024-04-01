using System;
using System.Collections.Generic;

namespace UEHCourse.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Courses = new HashSet<Course>();
        }

        public int SupplierId { get; set; }
        public string? SupplierName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
