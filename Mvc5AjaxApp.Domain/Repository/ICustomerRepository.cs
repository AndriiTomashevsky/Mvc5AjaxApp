using Mvc5AjaxApp.Domain.Entities;
using System.Collections.Generic;

namespace Mvc5AjaxApp.Domain.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Customers { get; }
        void SaveCustomer(Customer customer);
    }
}
