using System.Collections.Generic;
using Mvc5AjaxApp.Domain.Entities;

namespace Mvc5AjaxApp.Domain.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        AppDbContext appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Customer> Customers
        {
            get
            {
                return appDbContext.Customers.Include("Digits");
            }
        }

        public void SaveCustomer(Customer customer)
        {
            if (customer.CustomerId == 0)
            {
                appDbContext.Customers.Add(customer);
            }
            else
            {
                Customer dbEntry = appDbContext.Customers.Find(customer.CustomerId);

                if (customer != null)
                {
                    dbEntry.Digits = customer.Digits;
                }
            }
            appDbContext.SaveChanges();
        }
    }
}
