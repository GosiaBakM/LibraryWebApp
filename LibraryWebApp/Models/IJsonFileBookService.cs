using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public interface IJsonFileBookService
    {
        //List<Book> AllBooks { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }
        //TODO change to private 
        public string JsonFileName { get; }
        public IEnumerable<Book> GetBooks();
        public void SaveBooks(IEnumerable<Book> books);
    }
}
