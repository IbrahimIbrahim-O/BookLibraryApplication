using AutoMapper;
using BookLibraryApplication.Dto.Book;
using BookLibraryApplication.Dto.Category;
using BookLibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApplication
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, GetBookDto>();
            CreateMap<AddBookDto, Book>();
            CreateMap<GetBookDto, Book>();
            //CreateMap<GetCategoryDto, Category>();
        }
    }
}
