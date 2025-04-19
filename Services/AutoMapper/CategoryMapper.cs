using AutoMapper;
using Entities.DataManipulationObject.CategoryDtos;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<CategoryForCreationDto, Category>();
            CreateMap<Category, ResultCategoryDto>();
            CreateMap<Category, CategoryForUpdateDto>().ReverseMap();
        }
    }
}
