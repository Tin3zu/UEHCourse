using System;
using System.Collections.Generic;

namespace UEHCourse.Models
{
    public partial class Course
    {
        public Course()
        {
            Customers = new HashSet<Customer>();
        }

        public int CourseId { get; set; }
        public int? FieldId { get; set; }
       
        public int? SupplierId { get; set; }
        public string? CourseName { get; set; }
        public string SupplierName {  get; set; }
        public string FieldName { get; set; }
        public decimal? Price { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? StartDay { get; set; }
        public DateTime? EndDay { get; set; }
        public string? Description { get; set; }
        public int? Slot { get; set; }
        public bool? Active { get; set; }
        public string? CourseImage { get; set; }
        public string? Status { get; set; }
        public string? Discount { get; set; }

        public virtual ImageName CourseNavigation { get; set; } = null!;
        public virtual Field? Field { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
