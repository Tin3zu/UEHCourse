using System;
using System.Collections.Generic;

namespace UEHCourse.Models
{
    public partial class Customer
    {
        public string CustomerId { get; set; } = null!;
        public string? Cname { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Address { get; set; }
        public string? Cemail { get; set; }
        public string? Cphone { get; set; }
        public string? Clogin { get; set; }
        public string? Cpassword { get; set; }
        public string? Avatar { get; set; }
        public DateTime? CcreateDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public string? Mssv { get; set; }
        public int? CourseId { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string? PaymentId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Payment? Payment { get; set; }
    }
}
