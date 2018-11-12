using System.Collections.Generic;

namespace Mvc5AjaxApp.Domain.Entities
{
    public class Customer
    {
        public long CustomerId { get; set; }
        public long? DerivedId { get; set; }
        public ICollection<Digit> Digits { get; set; }
    }
}
