using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApplication.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = "Joys of MotherHood";
        public string Description { get; set; } = "About the expectations of the African Woman";
        public string ISBN { get; set; } = "12548966";
        public bool IsFavorite { get; set; }


        //Navigation Properties
        public int CategoryId { get; set; } 
        public Category Category { get; set; }

        public List<AuthorBook> AuthorBooks { get; set; }

    }
}
