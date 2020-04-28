using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LibraryWebApp.Models
{
    public class JsonBookRepository : IBookRepository
    {
        private readonly IJsonFileConnector jsonBookData;
        private List<Book> _allBooks;
        public List<Book> AllBooks { get => _allBooks;}

        public JsonBookRepository(IJsonFileConnector jsonFileBookService)
        {
            this.jsonBookData = jsonFileBookService;
            _allBooks = jsonBookData.GetBooks().ToList();
        }

        public IEnumerable<Book> GetAllBooks() => jsonBookData.GetBooks();

        public void Add(Book book)
        {
            AllBooks.Add(book);
        }

        public Book FindByAuthor()
        {
            throw new NotImplementedException();
        }

        public bool SaveData()
        {
            return jsonBookData.SaveBooks(AllBooks);
        }

        public Book FindByISBN(int bookISBN) =>
            jsonBookData.GetBooks().FirstOrDefault(b => b.ISBN == bookISBN);

        public IEnumerable<Book> FindByTitle(string bookTitle) =>
            jsonBookData.GetBooks().Where(b => b.Title == bookTitle);

        public void UpdateBookList(Book modifiedBook, int ISBN) 
        {
            AllBooks.RemoveAll(b => b.ISBN == ISBN);
            AllBooks.Add(modifiedBook);
        }

        public void Delete(Book book)
        {
            AllBooks.Remove(book);
        }
    }
}

