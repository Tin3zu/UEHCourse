using System;
using System.Collections.Generic;

namespace UEHCourse.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Customers = new HashSet<Customer>();
        }

        public string PaymentId { get; set; } = null!;
        public string? PaymentStatus { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
