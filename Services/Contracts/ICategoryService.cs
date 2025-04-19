using Entities.DataManipulationObject.CategoryDtos;
using Entities.RequestFeatures;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        Task<(IEnumerable<ResultCategoryDto>categoryDtos,MetaData metaData)> GetAllCategoriesAsync(CategoryParameters categoryParameters,bool trackChanges);
        Task<ResultCategoryDto> GetOneCategoryByIdAsync(int id, bool trackChanges);
        Task CreateOneCategoryAsync(CategoryForCreationDto categoryDto);
        Task UpdateOneCategoryAsync(int Id,CategoryForUpdateDto categoryDto,bool trackChanges);
        Task DeleteOneCategoryAsync(int id, bool trackChanges);
    }
}
