using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public interface IBookRepository
    {
        //void AddBook(Book book);
        IEnumerable<Book> GetAllBooks();
        Book FindByISBN(int ISBN);
        Book FindByAuthor();
        Book FindByTitle();
        void Add(Book book);

    }
}
