using BookLibraryApplication.Data;
using BookLibraryApplication.Dto.Category;
using BookLibraryApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApplication.Services.BookService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task<MessageOut> AddCategory(AddCategoryDto payload)
        {
            try
            {
                var newCategory = new Category()
                {
                    CategoryName = payload.CategoryName
                };

                var checkForDuplicate = await _context.Categories.Where(x => x.CategoryName == payload.CategoryName).FirstOrDefaultAsync();

                if (checkForDuplicate == null)

                {
                    _context.Categories.Add(newCategory);
                    await _context.SaveChangesAsync();

                    return new MessageOut { Message = $"{newCategory.CategoryName} was added succesfully", IsSuccessful = true };
                }
                else
                {
                    return new MessageOut { IsSuccessful = false, Message = $"{newCategory.CategoryName} already exists" };
                }
            }
            catch (Exception ex)
            {
                return new MessageOut { IsSuccessful = false, Message = ex.Message };
            }
        }

     
        public  async Task<ServiceResponse<List<GetCategoryDto>>> GetAllCategories()
        {
            var serviceResponse = new ServiceResponse<List<GetCategoryDto>>();

            try
            {
                var dbCategories = await (from category in _context.Categories

                                     select new GetCategoryDto
                                     {
                                         Id = category.Id,
                                         CategoryName = category.CategoryName
                                     }).ToListAsync();

                serviceResponse.Data = dbCategories;
            }
            catch (Exception ex)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;

        }

        public async Task<MessageOut> UpdateCategory(int CategoryId, UpdateCategoryDto updatedCategory)
        {
            try
            {
                var singleCategory = await _context.Categories.FirstOrDefaultAsync(x => x.Id == CategoryId);
                if (singleCategory != null)
                {
                    singleCategory.CategoryName = updatedCategory.CategoryName;

                    await _context.SaveChangesAsync();
                    return new MessageOut { IsSuccessful = true, Message = $"{singleCategory.CategoryName} updated successfully" };
                }
                else
                {
                    return new MessageOut { IsSuccessful = false, Message = $"{updatedCategory.CategoryName} does not exist, please try again" };
                }
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

        public async Task<MessageOut> DeleteCategory(int id)
        {

            try
            {
                Category singleCategory = await _context.Categories.Where(b => b.Id == id).FirstOrDefaultAsync();
                if (singleCategory != null)
                {
                    _context.Remove(singleCategory);
                    await _context.SaveChangesAsync();

                    return new MessageOut()
                    {
                        IsSuccessful = true,
                        Message = $"{singleCategory.CategoryName} was deleted successfully"
                    };
                }
                else 
                {
                    return new MessageOut
                    {
                        IsSuccessful = false,
                        Message = "Category was not found, please try again"
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
