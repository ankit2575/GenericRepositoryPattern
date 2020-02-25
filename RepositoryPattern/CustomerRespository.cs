using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    public class CustomerRespository : ICustomerRepository
    {
        private NorthwindEntities context;
        public CustomerRespository()
        {
            this.context = new NorthwindEntities();
        }
        public void DeleteCustomer(int customerId)
        {
            Customer customer = context.Customers.Find(customerId);
            context.Customers.Remove(customer);
            save();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public Customer GetCustomerById(int customerId)
        {
            return context.Customers.Find(customerId);
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return context.Customers.ToList();
            
        }
        public void InsertCustomer(Customer customer)
        {
            context.Customers.Add(customer);
            save();
        }
        public void save()
        {
            context.SaveChanges();
        }
        public void UpdateCustomer(Customer customer)
        {
            context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            save();
        }
    }
}