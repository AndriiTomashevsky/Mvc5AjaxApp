using Mvc5AjaxApp.Domain.Entities;
using System.Collections.Generic;

namespace Mvc5AjaxApp.WebUI.Models
{
    public class CustomerViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public string SelectedId { get; set; }
    }
}