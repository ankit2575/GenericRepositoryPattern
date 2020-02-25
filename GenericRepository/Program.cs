using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository
{
    class Program
    {
        
        static void Main(string[] args)
        {
            BaseRepository<Product> baseRepository = new BaseRepository<Product>();
            foreach (var item in baseRepository.Get())
            {
                Console.WriteLine(item.ProductName+"\t"+item.ProductID);
            }
        }
    }
}
