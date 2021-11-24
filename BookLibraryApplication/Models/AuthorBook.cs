using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApplication.Models
{
    public class AuthorBook
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }


        public int AuthorsId { get; set; }
        public Author Author { get; set; }
    }
}
