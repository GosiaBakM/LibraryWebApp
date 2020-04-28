using AutoMapper;
using LibraryWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public BooksController(IBookRepository bookRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookModel>> Get()
        {
            try
            {
                var allBooks = _bookRepository.GetAllBooks();
                if (allBooks == null) return NotFound("Sorry books weren't found");
                return _mapper.Map<BookModel[]>(allBooks);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database connection error");
            }
        }

        [HttpGet("{ISBN:int}")]
        public ActionResult<BookModel> GetById(int ISBN)
        {
            try
            {
                var book = _bookRepository.FindByISBN(ISBN);
                if (book == null) return NotFound("Sorry the book was not found");
                return _mapper.Map<BookModel>(book);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database connection error");
            }
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<BookModel>> GetByTitle(string bookTitle)
        {
            if(string.IsNullOrEmpty(bookTitle)) return BadRequest("Could not use current title of book");
            try
            {
                var booksByTitle = _bookRepository.FindByTitle(bookTitle);
                if(booksByTitle == null) return NotFound("Sorry the book with given title was not found");
                return _mapper.Map<BookModel[]>(booksByTitle);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database connection error");
            }
        }

        [HttpPost]
        public ActionResult<BookModel> AddBook(BookModel bookModel) 
        {         
            try
            {
                return AddBookToDataStore(bookModel);              
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database connection error");
            }
        }

        private ActionResult<BookModel> AddBookToDataStore(BookModel bookModel)
        {
            var bookModelEndPoint = _linkGenerator.GetPathByAction($"{nameof(GetById)}", $"{nameof(BooksController)}", 
                                    new { ISBN = bookModel.isBorrowed });
            if (bookModel == null) return BadRequest("Can not create new book");
            var newBook = _mapper.Map<Book>(bookModel);
            _bookRepository.Add(newBook);
            if (_bookRepository.SaveData()) return Created(bookModelEndPoint, _mapper.Map<BookModel>(newBook));
            
            return BadRequest();
        }

        [HttpPut("{ISBN:int}")]
        public ActionResult<BookModel> Update(int ISBN, BookModel bookModel)
        {
            try
            {
                var bookByISBN = _bookRepository.FindByISBN(ISBN);
                if (bookByISBN == null) return NotFound("Can not find book to update");
                _mapper.Map(bookModel, bookByISBN );
                if (_bookRepository.SaveData()) return _mapper.Map<BookModel>(bookByISBN);
            }
            catch (Exception)
            {
                this.StatusCode(StatusCodes.Status500InternalServerError, "Database connection error");
            }
            return BadRequest();
        }
    }
}
