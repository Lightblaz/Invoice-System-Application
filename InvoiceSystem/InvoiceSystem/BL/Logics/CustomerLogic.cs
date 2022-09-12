using DAL.DataManager;
using DAL.Models;
using DAL.ViewModels;
using InvoiceSystem.Validation;
using System.ComponentModel.DataAnnotations;

namespace InvoiceSystem.BL.Logics
{
    public class CustomerLogic : ICustomerLogic
    {
        private readonly ICustomerManager _customerManager;
        public CustomerLogic(ICustomerManager customerManger)
        {
            _customerManager = customerManger;
        }
        public bool CreateCustomer(Customer customer)
        {
            (var msg , var valid)  =CustomerValidation.Validate(customer);
            if (!valid) 
            {
                return false;
            }
            /* var sucess = 0;
             using (var db = new InvoicingSystemContext())
             {
                 db.Customers.Add(customer);
                 sucess = db.SaveChanges();
             }
             return sucess > 0;*/
            return _customerManager.AddCustomer(customer);
        }
    }
}
