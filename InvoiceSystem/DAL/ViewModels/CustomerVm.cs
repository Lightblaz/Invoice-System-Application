using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class CustomerVm
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Number { get; set; }
        public DateTime? Dob { get; set; }
        public string? Gender { get; set; }
        public string? GenderDescription {
            get { return Gender == "f" ? "Female" : "Male"; }
        }
       // public virtual Customer? Customer { get; set; } 
    }
}
