using BookLibraryApplication.Dto.Category;
using BookLibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApplication.Dto.Book
{
    public class GetBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; } 
        public string ISBN { get; set; } 
        public string CategoryName { get; set; }
        public List<string> AuthorNames { get; set; }
    }
}
