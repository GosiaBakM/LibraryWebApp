using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace LibraryWebApp.Models
{
    public interface IJsonFileConnector
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        public string JsonFileName { get; }
        public IEnumerable<Book> GetBooks();
        public bool SaveBooks(IEnumerable<Book> books);
    }
}
