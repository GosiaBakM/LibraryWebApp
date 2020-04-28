using System;

namespace LibraryWebApp.Models
{
    public class Book 
    {
        public int ISBN { get; set; }
        public string Title { get; set; }
        //public List<Author> AuthorList { get; set; }
        public string Author{ get; set; }
        //public DateTime LastBorrowDate { get; set; }
        public Customer Customer { get; set; }
        public bool isBorrowed { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Book)) return false;
                   Book other = (Book)obj;
            return ISBN == other.ISBN;
        }
    }
}
