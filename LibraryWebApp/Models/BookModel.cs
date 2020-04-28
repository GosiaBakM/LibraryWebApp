namespace LibraryWebApp.Models
{
    public class BookModel
    {
        public int ISBN { get; set; }
        public string Title { get; set; }
        //public List<Author> AuthorList { get; set; }
        public Author Author{ get; set; }
        //public DateTime LastBorrowDate { get; set; }
        public Customer Customer { get; set; }
        public bool IsBorrowed { get; set; }

    }
}
