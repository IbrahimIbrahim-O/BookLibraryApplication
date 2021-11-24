using BookLibraryApplication.Dto.Book;
using BookLibraryApplication.Models;
using BookLibraryApplication.Services.BookService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace BookLibraryApplication.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

      
        /// <summary>
        /// Returns All Books in the Books Application
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllBooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServiceResponse<List<GetBookDto>>>> GetAllBooks()
        {
            return Ok(await _bookService.GetAllBooks());
        }



        /// <summary>
        /// Returns a single book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetBookById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServiceResponse<GetBookDto>>> GetBookById(int id)
        {
            return Ok(await _bookService.GetBookById(id));
        }

        /// <summary>
        /// Adds a new book with authors to the applicaion
        /// </summary>
        /// <param name="newBook"></param>
        /// <returns></returns>
        [HttpPost("AddBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MessageOut>> AddBook(AddBookDto newBook)
        {
            return Ok(await _bookService.AddBookWithAuthors(newBook));
        }

        /// <summary>
        /// Updates a book by the provided id
        /// </summary>
        /// <param name="BookId"></param>
        /// <param name="updatedBook"></param>
        /// <returns></returns>
        [HttpPut("UpdateBook/{BookId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MessageOut>> UpdateBook(int BookId, UpdateBookDto updatedBook)
        {
            var response = await _bookService.UpdateBook(BookId, updatedBook);
            
            if(response.IsSuccessful == false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        /// <summary>
        /// Adds Books to the Favorite List
        /// </summary>
        /// <param name="favoriteBooks"></param>
        /// <returns></returns>
        [HttpPost("AddBooksToFavoriteList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MessageOut>> AddBooksToFavoriteList(AddFavoriteBooksDto favoriteBooks)
        {
            return Ok(await _bookService.AddBooksToFavoriteList(favoriteBooks));
        }

        /// <summary>
        /// Returns List of Favorite books
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetListOfFavoriteBooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServiceResponse<List<GetBookDto>>>> GetListOfFavoriteBooks()
        {
            return Ok(await _bookService.GetListOfFavoriteBooks());
        }

        /// <summary>
        /// Deletes a book by the given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MessageOut>> DeleteBook(int id)
        {
            var response = await _bookService.DeleteBook(id);

            if(response.IsSuccessful == false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
