
using DTOs.CategoryDtos;

namespace BookStore.Blazor.Contracts;
public interface ICategoryService
{
    Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
    Task<ResultCategoryDto> GetCategoryAsync(int id);
    Task<HttpResponseMessage> AddCategoryAsync(CategoryForCreationDto categorydto);
    Task<HttpResponseMessage> EditCategoryAsync(CategoryForUpdateDto categorydto);
    Task<HttpResponseMessage> DeleteCategoryAsync(int id);
}

