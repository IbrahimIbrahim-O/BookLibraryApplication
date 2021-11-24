using BookLibraryApplication.Dto.Author;
using BookLibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApplication.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<MessageOut> AddAuthor(AddAutorDto payload);
        Task<ServiceResponse<List<GetAuthorDto>>> GetAllAuthors();
        Task<MessageOut> DeleteAuthor(int id);

    }
}
