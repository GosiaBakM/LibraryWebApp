using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryWebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult List()
        {
            var books = _bookRepository.GetAllBooks();
            return View(books);
        }

        public IActionResult Details(int bookISBN) 
        {
            var bookByISBN = _bookRepository.FindByISBN(bookISBN);
            return View(bookByISBN);
        }

        public IActionResult AddNew()
        {
            //var book = new Book();
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(Book book)
        {
            _bookRepository.Add(book);
            return Redirect("/Book/List");
        }


    }
}
