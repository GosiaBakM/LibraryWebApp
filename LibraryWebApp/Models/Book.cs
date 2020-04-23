using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class Book
    {
        public int ISBN { get; set; }
        public string Title { get; set; }
        //public List<Author> AuthorList { get; set; }
        public string Author{ get; set; }
        //public DateTime LastBorrowDate { get; set; }
        public string Customer { get; set; }
        public bool isBorrowed { get; set; }

    }
}
