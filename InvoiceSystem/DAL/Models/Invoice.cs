using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Invoice
    {
        public int InvoiceNo { get; set; }
        public DateTime? Date { get; set; }
        public string? CusName { get; set; }
        public string? ProNames { get; set; }
        public string? ProUnits { get; set; }
        public string? UnitPrice { get; set; }
        public string? TotalPrice { get; set; }
        public string? Discount { get; set; }
        public int? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
