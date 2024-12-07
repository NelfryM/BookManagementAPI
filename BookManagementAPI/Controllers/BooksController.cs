using BookManagementAPI.Models;
using BookManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController()
        {
            _bookService = new BookService();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_bookService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null) return NotFound(new { Message = "Libro no encontrado." });

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Book book)
        {
            if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author) || string.IsNullOrEmpty(book.Genre))
                return BadRequest(new { Message = "Title, Author y Genre son obligatorios." });

            if (book.PublishedYear <= 0)
                return BadRequest(new { Message = "PublishedYear debe ser un número positivo." });

            _bookService.Add(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Book updatedBook)
        {
            if (string.IsNullOrEmpty(updatedBook.Title) || string.IsNullOrEmpty(updatedBook.Author) || string.IsNullOrEmpty(updatedBook.Genre))
                return BadRequest(new { Message = "Title, Author y Genre son obligatorios." });

            if (updatedBook.PublishedYear <= 0)
                return BadRequest(new { Message = "PublishedYear debe ser un número positivo." });

            var updated = _bookService.Update(id, updatedBook);
            if (!updated) return NotFound(new { Message = "Libro no encontrado." });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _bookService.Delete(id);
            if (!deleted) return NotFound(new { Message = "Libro no encontrado." });

            return NoContent();
        }
    }
}