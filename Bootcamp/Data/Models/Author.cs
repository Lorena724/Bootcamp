using Bootcamp.Data.Base;

namespace Bootcamp.Data.Models
{
    public class Author:BaseClass
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        //Navigations Properties
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
