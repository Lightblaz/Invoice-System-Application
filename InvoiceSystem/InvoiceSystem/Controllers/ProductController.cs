using Microsoft.AspNetCore.Mvc;
using DAL.Models;

namespace InvoiceSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            using(var db = new InvoicingSystemContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }

            return new JsonResult(true);
        }

        [HttpGet]
        public Product? GetProduct(int id)
        {
            using(var db = new InvoicingSystemContext())
            {
                return db.Products.Where(p => p.Id == id).FirstOrDefault();
            }
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {

            using (var db = new InvoicingSystemContext())
            {
                return db.Products.ToList();
            }
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            int success = 0;
            using (var db = new InvoicingSystemContext())
            {
                var productToDelete = db.Products.Where(p => p.Id == id).FirstOrDefault();
                if (productToDelete != null)
                {
                    try
                    {
                        db.Products.Remove(productToDelete);
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
        public IActionResult UpdateProduct(Product product)
        {
            int records = 0;
            using (var db = new InvoicingSystemContext())
            {
                db.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
                var productExist = db.Products.Where(p => p.Id == product.Id).FirstOrDefault();
                if (productExist != null)
                {
                    db.Products.Update(product);
                    records = db.SaveChanges();
                }
            }
            return new JsonResult(records > 0);
        }
    }
}
