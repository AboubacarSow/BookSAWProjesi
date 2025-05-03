
using DTOs.CategoryDtos;

namespace BookStore.Blazor.Contracts;
public interface ICategoryService
{
    Task<List<ResultCategoryDto>> GetAllCategoriesAsync(bool trackChanges);
    Task<ResultCategoryDto> GetCategoryAsync(int id, bool trackCkanges);
    Task<HttpResponseMessage> AddCategoryAsync(CategoryForCreationDto categorydto);
    Task<HttpResponseMessage> EditCategoryAsync(CategoryForUpdateDto categorydto);
    Task<HttpResponseMessage> DeleteCategoryAsync(int id);
}

