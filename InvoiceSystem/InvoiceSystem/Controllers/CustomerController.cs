using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using DAL.ViewModels;
using AutoMapper;
using InvoiceSystem.BL;
//using System.Web.Http;

namespace InvoiceSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    //[RoutePrefix("Api/Customers")]
    public class CustomerController : ControllerBase
    {
        #region
        [HttpPost]
        public IActionResult AddCustomer(CustomerVm customer)
        {
            int records = 0;
            using (var db = new InvoicingSystemContext())
            {
                db.Customers.Add(new Customer { Address = customer.Address, 
                    Dob = customer.Dob , 
                    Email = customer.Email , 
                    Gender = customer.Gender , 
                    Id = customer.Id , 
                    Name = customer.Name , 
                    Number = customer.Number});
                records = db.SaveChanges();
            }

            return new JsonResult(records > 0);
        }

        [HttpGet]
        public Customer? GetCustomer(int id)        // ? = nullable (customer)
        {
            //AutoMapper.Mapper mapper;
            using (var db = new InvoicingSystemContext())
            {
                return db.Customers.Where(c => c.Id == id).FirstOrDefault();
            }
        }

        [HttpGet]
        public IEnumerable<Customer> GetAllCustomer()
        {

            using (var db = new InvoicingSystemContext())
            {
                return db.Customers.ToList();
            }
        }

        [HttpGet]
        public IEnumerable<Customer> GetAllCustomerFemale()
        {
            using (var db = new InvoicingSystemContext())
            {
                return db.Customers.Where(c => c.Gender == "f").ToList();
            }
        }

        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            int success= 0;
            using (var db = new InvoicingSystemContext())
            {
                var customerToDelete =  db.Customers.Where(c => c.Id == id).FirstOrDefault();
                if (customerToDelete != null)
                {
                    try
                    {
                        db.Customers.Remove(customerToDelete);
                        success = db.SaveChanges();
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
                
            }
            return new JsonResult(success > 0);
        }

        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer)
        {
            int records = 0;
            using (var db = new InvoicingSystemContext())
            {
                db.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
                var customerExist = db.Customers.Where(c => c.Id == customer.Id).FirstOrDefault();
                if(customerExist != null)
                {
                    db.Customers.Update(customer);
                    records = db.SaveChanges();
                }
            }
            return new JsonResult(records > 0);
        }
        #endregion
        private readonly ICustomerLogic _customerLogic;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerLogic customerLogic , IMapper mapper)
        {
            _customerLogic = customerLogic;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateCustomer_ControllerCNTR(CustomerVm customerVm)      //controller
        {
            Customer customer = _mapper.Map<CustomerVm, Customer>(customerVm);          //<source , destination>
            
            var done = _customerLogic.CreateCustomer(customer);       //logic
            return new JsonResult(done);
        }


        //GET REQUEST USING VM  

        [HttpGet]
        public IEnumerable<CustomerVm> GetCustomerVM()
        {
            using (var db = new InvoicingSystemContext())
            {
                var customer = db.Customers.ToList();
                return _mapper.Map<List<Customer>, List<CustomerVm>>(customer);
            }
        }
    }
}
