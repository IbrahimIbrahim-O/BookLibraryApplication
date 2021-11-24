using AutoMapper;
using BookLibraryApplication.Data;
using BookLibraryApplication.Dto.Book;
using BookLibraryApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApplication.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly DataContext _context;

        public BookService(DataContext context)
        {
            _context = context;
        }


        public async Task<MessageOut> AddBookWithAuthors(AddBookDto payload)
        {
            try
            {
                var newBook = new Book
                {
                    Title = payload.Title,
                    Description = payload.Description,
                    ISBN = payload.ISBN,
                    CategoryId = payload.CategoryId,
                };

                _context.Books.Add(newBook);
                await _context.SaveChangesAsync();

                foreach (var id in payload.AuthorIds)
                {
                    var newBookAuthors = new AuthorBook
                    {
                        BookId = newBook.Id,
                        AuthorsId = id
                    };

                    _context.AuthorsBooks.Add(newBookAuthors);
                    await _context.SaveChangesAsync();
                }

                return new MessageOut { IsSuccessful = true, Message = $"{newBook.Title} was added succesfully" };
            }

            catch(Exception ex)
            {
                return new MessageOut
                {
                    IsSuccessful = false,
                    Message = ex.Message
                };
            }

        }

        public async Task<ServiceResponse<List<GetBookDto>>> GetAllBooks()
        {
            var serviceResponse = new ServiceResponse<List<GetBookDto>>();

            try
            {
                var dbBooks = await (from book in _context.Books
                                     join category in _context.Categories
                                     on book.CategoryId equals category.Id 

                                     select new GetBookDto
                                     {
                                         Id = book.Id,
                                         Title = book.Title,
                                         Description = book.Description,
                                         ISBN = book.ISBN,
                                         CategoryName = category.CategoryName,
                                         AuthorNames = book.AuthorBooks.Select(n => n.Author.AuthorName).ToList()

                                     }).ToListAsync();

                serviceResponse.Data = dbBooks;
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
          
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetBookDto>> GetBookById(int id)
        {
            var serviceResponse = new ServiceResponse<GetBookDto>();

            try
            {
                var dbBook = await (from book in _context.Books.Where(book => book.Id == id)
                                    join category in _context.Categories
                                    on book.CategoryId equals category.Id
                                    select new GetBookDto
                                    {
                                        Id = book.Id,
                                        Title = book.Title,
                                        Description = book.Description,
                                        ISBN = book.ISBN,
                                        CategoryName = category.CategoryName,
                                        AuthorNames = book.AuthorBooks.Select(n => n.Author.AuthorName).ToList()

                                    }).FirstOrDefaultAsync();

                serviceResponse.Data = dbBook;
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
           
            return serviceResponse;
        }

        public async Task<MessageOut> UpdateBook(int BookId, UpdateBookDto updatedBook)
        {

            try
            {
                var singleBook = await _context.Books.FirstOrDefaultAsync(x => x.Id == BookId);
                if(singleBook != null)
                {
                    singleBook.Title = updatedBook.Title;
                    singleBook.Description = updatedBook.Description;
                    singleBook.ISBN = updatedBook.ISBN;
                    singleBook.CategoryId = updatedBook.CategoryId;

                    await _context.SaveChangesAsync();

                }
                return new MessageOut { IsSuccessful = true, Message = $"{singleBook.Title} updated successfully" };
            }
            catch (Exception ex)
            {

                return new MessageOut
                {
                    IsSuccessful = false,
                    Message = ex.Message
                };
            }


        }

        public async Task<MessageOut> DeleteBook(int id)
        {

            try
            {
                Book singleBook = await _context.Books.Where(b => b.Id == id).FirstOrDefaultAsync();
                if(singleBook != null)
                {
                    _context.Remove(singleBook);
                    await _context.SaveChangesAsync();

                    return new MessageOut()
                    {
                        IsSuccessful = true,
                        Message = $"{singleBook.Title} deleted successfully"
                    };
                }
                else
                {
                    return new MessageOut
                    {
                        IsSuccessful = false,
                        Message = "Book was not found, Please try again"
                    };
                }
              
            }
            catch (Exception ex)
            {
                return new MessageOut()
                {
                    IsSuccessful = false,
                    Message = ex.Message
                };
            }

        }

        public async Task<MessageOut> AddBooksToFavoriteList(AddFavoriteBooksDto favoriteBooks)
        {
            try
            {
                foreach (int id in favoriteBooks.FavoriteBooksIds)
                {
                    var singleBook = await _context.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if(singleBook != null)
                    {
                        singleBook.IsFavorite = true;

                        //_context.Books.Update(singleBook);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        return new MessageOut { IsSuccessful = false, Message = "This Book can not be found, please try again" };
                    }
                }
                return new MessageOut
                {
                    IsSuccessful = true,
                    Message = "Book added to favorite list's successfully"
                };
            }
            catch (Exception ex)
            {

                return new MessageOut
                {
                    IsSuccessful = true,
                    Message = ex.Message 
                };
            }
          
        }

        public async Task<ServiceResponse<List<GetBookDto>>> GetListOfFavoriteBooks()
        {
            var serviceResponse = new ServiceResponse<List<GetBookDto>>();

            try
            {
                var dbBooks = await(from book in _context.Books.Where(x => x.IsFavorite == true).DefaultIfEmpty()
                                    join category in _context.Categories
                                    on book.CategoryId equals category.Id

                                    select new GetBookDto
                                    {
                                        Id = book.Id,
                                        Title = book.Title,
                                        Description = book.Description,
                                        ISBN = book.ISBN,
                                        CategoryName = category.CategoryName,
                                        AuthorNames = book.AuthorBooks.Select(n => n.Author.AuthorName).ToList()

                                    }).ToListAsync();
                if(dbBooks.Count > 0)
                {
                    serviceResponse.Data = dbBooks;
                }
                else
                {
                    serviceResponse.Success = true;
                    serviceResponse.Message = "There are no Favorite Books, please create a list";
                }

            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
