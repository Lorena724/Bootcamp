using Bootcamp.Data.Models;

namespace Bootcamp.Data.DTOs.Author
{
    public class PostAuthorDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        //Navigations Properties
        public int BookId { get; set; }
    }
}
