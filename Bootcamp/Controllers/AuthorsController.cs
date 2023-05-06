using Bootcamp.Data;
using Bootcamp.Data.DTOs.Author;
using Bootcamp.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Bootcamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AppDbContext _appDbContext;
        public AuthorsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        //Krijo nje API endpoint per te marre te dhenat nga DB
        [HttpGet("GetAuthorById/{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _appDbContext.Authors.FirstOrDefault(x => x.Id == id);
            return Ok($"Autori me id = {id} u kthye me sukses!");
        }

        [HttpPost("AddAuthor")]
        public IActionResult AddAuthor([FromBody] PostAuthorDTO payload)
        {
            //1. Krijo nje objekt Student me te dhenat e marra nga payload
            Author newAuthor = new()
            {
                FirstName = payload.FirstName,
                LastName = payload.LastName,
                DateCreated = DateTime.UtcNow,

                BookId = payload.BookId
            };

            _appDbContext.Authors.Add(newAuthor);
            _appDbContext.SaveChanges();

            return Ok("Autori u krijua me sukses!");
        }

        [HttpPut("UpdateAuthor")]
        public IActionResult UpdateAuthor([FromBody] PutAuthorDTO payload, int id)
        {
            //1. Duke perdour ID marrim te dhenat nga databaza
            var author = _appDbContext.Authors.FirstOrDefault(x => x.Id == id);
            if (author == null)
                return NotFound();

            //2. Perditesojme Autorin e DB me te dhenat e payload-it
            author.FirstName = payload.FirstName;
            author.LastName = payload.LastName;
            author.BookId = payload.BookId;

            //3. Ruhen te dhenat ne database
            _appDbContext.Authors.Update(author);
            _appDbContext.SaveChanges();

            return Ok("Autori u modifikua me sukses!");
        }

        [HttpDelete("DeleteAuthor/{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            //1. Duke perdour ID marrim te dhenat nga databaza
            var author = _appDbContext.Authors.FirstOrDefault(x => x.Id == id);
            if (author == null)
                return NotFound();

            //2. Fshijme studentin nga DB
            _appDbContext.Authors.Remove(author);
            _appDbContext.SaveChanges();

            return Ok($"Autori me id = {id} u fshi me sukses!");
        }
    }
}
