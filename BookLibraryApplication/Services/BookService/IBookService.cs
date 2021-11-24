using BookLibraryApplication.Dto.Book;
using BookLibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApplication.Services.BookService
{
    public interface IBookService
    {
        Task<ServiceResponse<List<GetBookDto>>> GetAllBooks();
        Task<ServiceResponse<GetBookDto>> GetBookById(int id);
        Task<MessageOut> AddBookWithAuthors(AddBookDto newBook);
        Task<MessageOut> UpdateBook(int BookId, UpdateBookDto updatedBook);
        Task<MessageOut> DeleteBook(int id);
        Task<MessageOut> AddBooksToFavoriteList(AddFavoriteBooksDto favoriteBooks);
        Task<ServiceResponse<List<GetBookDto>>> GetListOfFavoriteBooks();
    }
}
