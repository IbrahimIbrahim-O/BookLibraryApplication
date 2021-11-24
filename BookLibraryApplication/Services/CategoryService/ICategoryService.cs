using BookLibraryApplication.Dto.Category;
using BookLibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApplication.Services.BookService
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<GetCategoryDto>>> GetAllCategories();
        Task<MessageOut> UpdateCategory(int CategoryId, UpdateCategoryDto updatedCategory);
        Task<MessageOut> AddCategory(AddCategoryDto payload);
        Task<MessageOut> DeleteCategory(int id);

    }
}
