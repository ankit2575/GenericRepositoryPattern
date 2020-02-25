using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RepositoryPattern
{
    public class NorthwindEntities: DbContext
    {
        
        public NorthwindEntities():base("ApplicationDb")
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
