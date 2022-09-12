using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataManager
{
    public class CustomerManager : ICustomerManager
    {
        public bool AddCustomer(Customer customer)
        {
            var sucess = 0;
            using (var db = new InvoicingSystemContext())
            {
                db.Customers.Add(customer);
                sucess = db.SaveChanges();
                // db.Customers.FromSqlRaw("SELECT * FROM customers");
                //db.database.ExecuteSQlcommand.createCustomer  //is the stored procedure
            }
            return (sucess > 0);
        }
    }
}
