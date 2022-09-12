using DAL.Models;
using System;
using System.Net.Mail;

namespace InvoiceSystem.Validation
{
    public class CustomerValidation
    {
        public static (List<String>, bool) Validate(Customer customer)
        {
            var errorMessages = new List<string>();
            bool valid = true;
            if (string.IsNullOrEmpty(customer.Name))
            {
                errorMessages.Add("Customer Name is required");
                valid = false;
            }
            return (errorMessages, valid);
        }

        public static bool EmailValidate(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.Email))
            {
                return false;
            }
            try
            {
                MailAddress m = new MailAddress(customer.Email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
