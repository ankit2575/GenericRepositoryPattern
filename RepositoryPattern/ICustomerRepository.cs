using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    public interface ICustomerRepository:IDisposable
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(int customerId);
        void InsertCustomer(Customer customer);
        void DeleteCustomer(int customerId);
        void UpdateCustomer(Customer customer);
        void save();
    }

}
