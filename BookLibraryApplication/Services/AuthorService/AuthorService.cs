using BookLibraryApplication.Data;
using BookLibraryApplication.Dto.Author;
using BookLibraryApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApplication.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        private readonly DataContext _context;

        public AuthorService(DataContext context)
        {
            _context = context;
        }


        
        public async Task<MessageOut> AddAuthor(AddAutorDto payload)
        {
            try
            {
                var newAuthor = new Author()
                {
                    AuthorName = payload.AuthorName
                };

                var checkForDuplicate = await _context.Authors.Where(x => x.AuthorName == payload.AuthorName).FirstOrDefaultAsync();

                if(checkForDuplicate == null)

                {
                    _context.Authors.Add(newAuthor);
                    await _context.SaveChangesAsync();

                    return new MessageOut { Message = $"{newAuthor.AuthorName} was added succesfully", IsSuccessful = true };
                }
                else
                {
                    return new MessageOut { IsSuccessful = false, Message = $"{newAuthor.AuthorName} already exists" };
                }
               
            }
            catch (Exception ex)
            {
                return new MessageOut { IsSuccessful = false, Message = ex.Message };
            }
           
        }

        public async Task<ServiceResponse<List<GetAuthorDto>>> GetAllAuthors()
        {
            var serviceResponse = new ServiceResponse<List<GetAuthorDto>>();

            try
            {
                var dbAuthors = await (from author in _context.Authors
                                    

                                     select new GetAuthorDto
                                     {
                                        Id = author.Id,
                                        AuthorName = author.AuthorName
                                     }).ToListAsync();

                serviceResponse.Data = dbAuthors;
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;

        }


        public async Task<MessageOut> DeleteAuthor(int id)
        {
            try
            {
                Author singleAuthor = await _context.Authors.Where(b => b.Id == id).FirstOrDefaultAsync();

                if(singleAuthor != null)
                {
                    _context.Remove(singleAuthor);
                    await _context.SaveChangesAsync();

                    return new MessageOut()
                    {
                        IsSuccessful = true,
                        Message = $"{singleAuthor.AuthorName} was deleted successfully"
                    };
                }
                else
                {
                    return new MessageOut()
                    {
                        IsSuccessful = false,
                        Message = "Author does not exist, please try again"
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

    }
}
