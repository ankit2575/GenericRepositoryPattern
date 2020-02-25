using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    class Program
    {        
        static void Main(string[] args)
        {
            
            CustomerRespository customer = new CustomerRespository();
            try
            {
                foreach(var item in customer.GetCustomers())
                {
                    Console.WriteLine(item.customerId+"\n"+item.customerName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }
    }
}
