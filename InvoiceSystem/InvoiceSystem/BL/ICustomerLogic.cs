using DAL.Models;
using DAL.ViewModels;

namespace InvoiceSystem.BL
{
    public interface ICustomerLogic
    {
        bool CreateCustomer(Customer customer);
    }
}
