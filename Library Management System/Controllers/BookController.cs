using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Library_Management_System.Models;
using Library_Management_System.Repository;
using Microsoft.AspNetCore.Authorization;
namespace Library_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBook _books;

        public BookController(IBook book)
        {
            _books = book;

        }
        // GET /api/books: Retrieve a list of all books.
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            List<Book> BookList = _books.GetAllBooks();

            return Ok(BookList);
        }

        // GET /api/books/{id}: Retrieve details of a specific book by ID.
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            Book book = _books.GetBookById(id);
            return Ok(book);
        }

        // POST /api/books: Add a new book to the library.
        [Authorize]
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (ModelState.IsValid == true)
            {
                _books.AddBook(book);
                _books.Save();
                return CreatedAtAction("GetByID", new { id = book.ID }, book);
            }
            return BadRequest(ModelState);
        }

        // PUT /api/books/{id}: Update an existing book's information.
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id )
        {
            Book book = _books.GetBookById(id);
            if(book != null)
            {
                _books.UpdateBook(book);
            }
            else
            {
                return BadRequest("Invalid Id");
            }
            return Ok(book);
        }

        // DELETE /api/books/{id}: Remove a book from the library.
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            Book book = _books.GetBookById(id);
            if (book != null)
            {
                _books.DeleteBook(id);
                return Ok(); 
            }
            else
            {
                return NotFound(); 
            }
        }

      
    }

   
}
