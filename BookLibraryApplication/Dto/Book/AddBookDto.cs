using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApplication.Dto.Book
{
    public class AddBookDto
    {
        public string Title { get; set; } 
        public string Description { get; set; } 
        public string ISBN { get; set; }
        public List<int> AuthorIds { get; set; }
        public int CategoryId { get; set; }


    }
}
