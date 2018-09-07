using myMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myMVC.Controllers
{
    public class CustomersController : Controller
    {
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "CustName";
            }
            var customers = new Customers();
            var allCustomers = new List<Customer>();
            allCustomers.Add(new Customer { CustName = "Harsh", Id = 1 });
            allCustomers.Add(new Customer { CustName = "Kirti", Id = 2 });

            //allCustomers.Sort();
            customers.AllCustomers = allCustomers;
            return View(customers);
        }

        [Route("customers/customer/{Id:min(1):max(10000)}")]
        public ActionResult GetByID(int Id)
        {
            var customers = new Customers();
            var allCustomers = new List<Customer>();
            allCustomers.Add(new Customer { CustName = "Harsh", Id = 1 });
            allCustomers.Add(new Customer { CustName = "Kirti", Id = 2 });
            Customer customer = allCustomers.Where(e => e.Id == Id).FirstOrDefault();
            return View(customer);
        }

    }
}