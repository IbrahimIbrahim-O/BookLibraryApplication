using BookLibraryApplication.Dto.Category;
using BookLibraryApplication.Models;
using BookLibraryApplication.Services.BookService;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        /// <summary>
        /// Returns all categories in the Application
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServiceResponse<List<GetCategoryDto>>>> GetAllBooks()
        {
            return Ok(await _categoryService.GetAllCategories());
        }

        /// <summary>
        /// Adds a New Category to the Application
        /// </summary>
        /// <param name="newCategory"></param>
        /// <returns></returns>
        [HttpPost("AddCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MessageOut>> AddCategory(AddCategoryDto newCategory)
        {
            return Ok(await _categoryService.AddCategory(newCategory));
        }

        /// <summary>
        /// Updates a category
        /// </summary>
        /// <param name="CategoryiD"></param>
        /// <param name="updatedCategory"></param>
        /// <returns></returns>
        [HttpPut("UpdateCategory/{CategoryiD}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MessageOut>> UpdateCategory(int CategoryiD, UpdateCategoryDto updatedCategory)
        {
            var response = await _categoryService.UpdateCategory(CategoryiD, updatedCategory);

            if (response.IsSuccessful == false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        /// <summary>
        /// Deletes a Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MessageOut>> DeleteCategory(int id)
        {
            var response = await _categoryService.DeleteCategory(id);

            if (response.IsSuccessful == false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
