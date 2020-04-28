using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryWebApp.Models
{
    public class MockBookRepository : IBookRepository
    {
        public List<Book> AllBooks { get; }

        public MockBookRepository()
        {
            AllBooks = new List<Book>
            {
                new Book{ISBN = 1, Title = "W pustyni i w puszczy", Author = "Henryk Sienkiewicz", Customer = new Customer{ CustomerId = 1, Name = "Jan", Surname = "Kowalski"}, isBorrowed = false },
                new Book {ISBN = 2, Title = "Adam Mickiewicz", Author = "Pan Tadeusz", Customer = new Customer{ CustomerId = 1, Name = "Jan", Surname = "Kowalski"}, isBorrowed = true }
            };
        }

        public void Add(Book book)
        { 
            AllBooks.Add(book);
        }

        public Book FindByAuthor()
        {
            throw new NotImplementedException();
        }

        public Book FindByISBN(int bookISBN) => AllBooks.FirstOrDefault(b => b.ISBN == bookISBN);

        public IEnumerable<Book> GetAllBooks() => AllBooks;

        public IEnumerable<Book> FindByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public bool SaveData()
        {
            throw new NotImplementedException();
        }

        public void UpdateBookList(Book modifiedBook, int ISBN)
        {
            throw new NotImplementedException();
        }

        public void Delete(Book book)
        {
            throw new NotImplementedException();
        }
    }

}


