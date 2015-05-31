using Northwind.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Data.Context
{
    public class NorthwindContext:DbContext
    {
        public NorthwindContext()
            :base("NorthwindContext")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerDemographic> CustomerDemographics { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails{ get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Territory> Territories { get; set; }
        public override int SaveChanges()
         
        {
            foreach (DbEntityEntry kayit in ChangeTracker.Entries())
            {
                PropertyInfo nesne = kayit.Entity.GetType().GetProperty("RegisterDate");

                if (nesne != null)
                {
                    if (kayit.State == EntityState.Added)
                    {
                        kayit.Property("RegisterDate").CurrentValue = DateTime.Now;
                    }
                  
                }

            }
            return base.SaveChanges();
        }
    }


}
