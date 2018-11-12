using Mvc5AjaxApp.Domain.Entities;
using System.Data.Entity;

namespace Mvc5AjaxApp.Domain.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}

