using BookLibraryApplication.Dto.Author;
using BookLibraryApplication.Models;
using BookLibraryApplication.Services.AuthorService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        /// <summary>
        /// Adds a New Author to the Application
        /// </summary>
        /// <param name="newAuthor"></param>
        /// <returns></returns>
        [HttpPost("AddAuthor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MessageOut>> AddBook(AddAutorDto newAuthor)
        {
            return Ok(await _authorService.AddAuthor(newAuthor));
        }

        /// <summary>
        /// Returns all Authors already created in the Application
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllAuthors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServiceResponse<List<GetAuthorDto>>>> GetAllAuthors()
        {
            return Ok(await _authorService.GetAllAuthors());
        }

        /// <summary>
        /// Deletes Author by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MessageOut>> DeleteAuthor(int id)
        {
            var response = await _authorService.DeleteAuthor(id);

            if (response.IsSuccessful == false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }



    }
}
