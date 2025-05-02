
using DTOs.CategoryDtos;

namespace BookSAW.Contracts
{
    public interface ICategoryService
    {
        List<ResultCategoryDto> GetAllCategories(bool trackChanges);
        ResultCategoryDto GetCategory(int id, bool trackCkanges);
        Task AddCategory(CategoryForCreationDto categorydto);
        Task EditCategory(CategoryForUpdateDto categorydto);
        Task DeleteCategory(int id);
    }
}
