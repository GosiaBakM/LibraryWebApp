using Microsoft.CodeAnalysis.FlowAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class MockBookRepository : IBookRepository
    {
        public List<Book> AllBooks { get; }

        public MockBookRepository()
        {
            AllBooks = new List<Book>
            {
                new Book{ISBN = 1, Title = "W pustyni i w puszczy", Author = "Henryk Sienkiewicz", Customer = "Jan Kowalski", isBorrowed = false },
                new Book {ISBN = 2, Title = "Adam Mickiewicz", Author = "Pan Tadeusz", Customer = "Maria Nowak", isBorrowed = true }
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
           

        public Book FindByTitle()
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<Book> Books { get; set; }

        public IEnumerable<Book> GetAllBooks() => AllBooks;           
    }

}


