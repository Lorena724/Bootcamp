using Bootcamp.Data.Base;

namespace Bootcamp.Data.Models
{
    public class Book:BaseClass
    {
        
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        //Navigation Properties
        public List<Author> Authors { get; set; }

    }
}
