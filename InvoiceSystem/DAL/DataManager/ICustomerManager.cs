using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataManager
{
    public interface ICustomerManager
    {
        bool AddCustomer(Customer customer);
    }
}
