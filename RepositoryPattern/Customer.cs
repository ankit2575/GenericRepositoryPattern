﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int customerId { get; set; }
        public string customerName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
    }
}
