using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApplication.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        //Navigation Properties
        public List<Book> Books { get; set; }
    }
}
