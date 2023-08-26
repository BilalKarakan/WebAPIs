using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookApp.Data;

namespace BookApp.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationContext.Books;
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook( [FromRoute(Name = "id")] int id) 
        {
            var book = ApplicationContext.Books.Where(x => x.Id.Equals(id)).SingleOrDefault();

            if (book is null)
                return NotFound();
            
            return Ok(book);
        }
    }
}
