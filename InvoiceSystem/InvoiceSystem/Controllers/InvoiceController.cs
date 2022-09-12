using Microsoft.AspNetCore.Mvc;
using DAL.Models;

namespace InvoiceSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class InvoiceController : ControllerBase
    {
        [HttpPost]
        public IActionResult Addinvoice(Invoice invoice)
        {
            using(var db = new InvoicingSystemContext())
            {
                db.Invoices.Add(invoice);
                db.SaveChanges();
            }

            return new JsonResult(true);
        }

        [HttpGet]
        public Invoice? GetInvoice(int invoiceNo)
        {
            using(var db = new InvoicingSystemContext())
            {
                return db.Invoices.Where(i => i.InvoiceNo == invoiceNo).FirstOrDefault();
            }
        }

        [HttpGet]
        public IEnumerable<Invoice> GetAllInvoices()
        {

            using (var db = new InvoicingSystemContext())
            {
                return db.Invoices.ToList();
            }
        }

        [HttpDelete]
        public IActionResult DeleteInvoice(int invoiceNo)
        {
            int success = 0;
            using (var db = new InvoicingSystemContext())
            {
                var invoiceToDelete = db.Invoices.Where(i => i.InvoiceNo == invoiceNo).FirstOrDefault();
                if (invoiceToDelete != null)
                {
                    try
                    {
                        db.Invoices.Remove(invoiceToDelete);
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
        public IActionResult UpdateInvoice(Invoice invoice)
        {
            int records = 0;
            using (var db = new InvoicingSystemContext())
            {
                db.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
                var InvoiceExist = db.Invoices.Where(i => i.InvoiceNo == invoice.InvoiceNo).FirstOrDefault();
                if (InvoiceExist != null)
                {
                    db.Invoices.Update(invoice);
                    records = db.SaveChanges();
                }
            }
            return new JsonResult(records > 0);
        }

        [HttpGet]
        public IEnumerable<Invoice> GetAllInvoicesCustomer(string customerName)
        {

            using (var db = new InvoicingSystemContext())
            {
                return db.Invoices.ToList().Where(i => i.CusName == customerName);
            }
        }

        [HttpGet]
        public IEnumerable<Invoice> GetAllInvoicesDate(DateTime datestart , DateTime dateend)
        {
            using (var db = new InvoicingSystemContext())
            {
                return  
                    db.Invoices.Where(x => x.Date > datestart && x.Date < dateend);
            }
        }

        [HttpPost]
        public IActionResult Createinvoice(Invoice[] invoice)
        {
            using (var db = new InvoicingSystemContext())
            {
                db.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
                //db.Products.Where(p => p.Quantity > invoice.ProUnits)
                foreach(var invo in invoice)
                {
                    bool productAvailable = db.Products.Any(p => p.Quantity > int.Parse(invo.ProUnits) && p.Name == invo.ProNames);
                    if (!productAvailable)
                    {
                        continue;
                    }

                    //db.Invoices.Where(x => x.Date > new DateTime(2022, 08, 26));        //date and time comparing
                    db.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
                    db.Invoices.Add(invo);
                    var product = db.Products.Where(p => p.Name == invo.ProNames).First();
                    product.Quantity = product.Quantity - int.Parse(invo.ProUnits);
                    db.SaveChanges();
                }
            }
            return new JsonResult(true);
        }
    }
}
