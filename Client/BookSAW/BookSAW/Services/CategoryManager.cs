using BookSAW.Contracts;
using DTOs.CategoryDtos;
namespace Services
{
    public class CategoryManager : ICategoryService
    {
        
        public Task AddCategory(CategoryForCreationDto categorydto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditCategory(CategoryForUpdateDto categorydto)
        {
            throw new NotImplementedException();
        }

        public List<ResultCategoryDto> GetAllCategories(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public ResultCategoryDto GetCategory(int id, bool trackCkanges)
        {
            throw new NotImplementedException();
        }
    }
}