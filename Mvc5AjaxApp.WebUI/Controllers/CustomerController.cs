using Mvc5AjaxApp.Domain.Entities;
using Mvc5AjaxApp.Domain.Repository;
using Mvc5AjaxApp.WebUI.Infrastructure.Generator;
using Mvc5AjaxApp.WebUI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Mvc5AjaxApp.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerRepository repository;
        IDigitGenerator generator;

        public CustomerController(ICustomerRepository repository, IDigitGenerator generator)
        {
            this.repository = repository;
            this.generator = generator;
        }

        public ViewResult Generate()
        {
            string selectedId = (string)Session["SelectedId"];
            return View(new CustomerViewModel { Customers = repository.Customers, SelectedId = (string)Session["SelectedId"] });
        }

        public PartialViewResult GetIds(long? id, int? n)
        {
            if (id != null)
            {
                Customer customer = repository.Customers.Where(c => c.DerivedId == id).FirstOrDefault();
                ICollection<Digit> digits = customer?.Digits;

                if (n != null && n != 0)
                {
                    digits = generator.GenerateDigits(digits, n);
                }
                if (customer == null)
                {
                    repository.SaveCustomer(new Customer { DerivedId = id, Digits = digits });
                }
                else
                {
                    repository.SaveCustomer(customer);
                }
            }

            return PartialView(repository.Customers);
        }

        public PartialViewResult GetDigits(long? selectedId)
        {
            Customer customer = null;

            Session["SelectedId"] = selectedId.ToString();

            if (selectedId != null)
            {
                customer = repository.Customers.Where(item => item.DerivedId == selectedId).First();
            }

            return PartialView(customer);
        }
    }
}