using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class Customer
    { 
        public int CustomerId { get; private set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }       
    }
}
