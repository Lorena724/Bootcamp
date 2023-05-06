using Bootcamp.Data;
using Bootcamp.Data.DTOs.Book;
using Bootcamp.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Bootcamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private AppDbContext _appDbContext;
        public BooksController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        //Krijo nje API endpoint per te marre te dhenat nga DB
        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _appDbContext.Books.ToList();

            return Ok(allBooks);
        }

        //Krijo nje API endpoint per te marre te dhenat nga DB
        [HttpGet("GetBookById/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _appDbContext.Books.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook([FromBody] PostBookDTO payload)
        {
            Book newBook = new Book()
            {
                Title = payload.Title,
                Description = payload.Description,
                Rate = payload.Rate,
                Genre = payload.Genre,    
            };

            _appDbContext.Books.Add(newBook);
            _appDbContext.SaveChanges();

            return Ok("Libri u krijua me sukses!");
        }

        [HttpPut("UpdateBook")]
        public IActionResult UpdateBook([FromBody] PutBookDTO payload, int id)
        {
            //1. Duke perdour ID marrim te dhenat nga databaza
            var book = _appDbContext.Books.FirstOrDefault(x => x.Id == id);

            //2. Perditesojme Subjectin e DB me te dhenat e payload-it
            if (book == null)
                return NotFound();

            book.Title = payload.Title;
            book.Description = payload.Description;
            book.Rate = payload.Rate;
            book.Genre = payload.Genre;

            //3. Ruhen te dhenat ne database
            _appDbContext.Books.Update(book);
            _appDbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("DeleteBook/{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _appDbContext.Books.FirstOrDefault(x => x.Id == id);

            if (book == null)
                return NotFound();

            _appDbContext.Books.Remove(book);
            _appDbContext.SaveChanges();

            return Ok($"Libri me id = {id} u fshi me sukses!");
        }
    }
}
