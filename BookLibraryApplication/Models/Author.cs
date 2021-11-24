using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApplication.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }

        //Navigations Properties
        public List<AuthorBook> AuthorBooks { get; set; }
    }
}
