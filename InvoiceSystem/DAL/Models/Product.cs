using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float? PurchasePrice { get; set; }
        public float? SellingPrice { get; set; }
        public int? Quantity { get; set; }
    }
}
