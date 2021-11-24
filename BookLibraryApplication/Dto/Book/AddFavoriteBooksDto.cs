using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApplication.Dto.Book
{
    public class AddFavoriteBooksDto
    {
        public List<int> FavoriteBooksIds { get; set; }
    }
}
