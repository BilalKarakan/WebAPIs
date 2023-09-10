﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookApp.Data;
using BookApp.Models;

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

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest();

                ApplicationContext.Books.Add(book);
                return StatusCode(201, book);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            var result = ApplicationContext.Books.Find(x => x.Id.Equals(id));

            if (result is null)
                return NotFound();

            if(id != book.Id)
                return BadRequest();

            ApplicationContext.Books.Remove(result);
            book.Id = result.Id;
            ApplicationContext.Books.Add(book);
            return Ok(book);
        }
    }
}
