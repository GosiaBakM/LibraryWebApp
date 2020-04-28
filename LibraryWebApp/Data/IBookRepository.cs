﻿using System.Collections.Generic;

namespace LibraryWebApp.Models
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book FindByISBN(int ISBN);
        Book FindByAuthor();
        IEnumerable<Book> FindByTitle(string title);
        void Add(Book book);
        public bool SaveData();
    }
}
