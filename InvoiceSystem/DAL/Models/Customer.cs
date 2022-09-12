using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Number { get; set; }
        public DateTime? Dob { get; set; }
        public string? Gender { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
