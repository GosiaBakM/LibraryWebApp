using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class JsonBookRepository : IBookRepository
    {
        private readonly IJsonFileBookService jsonBookData;
        private List<Book> _allBooks;
        public List<Book> AllBooks { get { return _allBooks; } }
       
        public JsonBookRepository(IJsonFileBookService jsonFileBookService)
        {
            this.jsonBookData = jsonFileBookService;
            _allBooks = jsonBookData.GetBooks().ToList();
        }

        public void Add(Book book)
        {
            AllBooks.Add(book);
            jsonBookData.SaveBooks(AllBooks);
        }

        public Book FindByAuthor()
        {
            throw new NotImplementedException();
        }

        public Book FindByISBN(int bookISBN) => jsonBookData.GetBooks().FirstOrDefault(b => b.ISBN == bookISBN);


        public Book FindByTitle()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Book> GetAllBooks() => jsonBookData.GetBooks();
    }
}
