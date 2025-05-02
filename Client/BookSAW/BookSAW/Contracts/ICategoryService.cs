
namespace BookSAW.Contracts
{
    public interface ICategoryService
    {
        List<ResultCategoryDto> GetAllCategories(bool trackChanges);
        List<ResultCategoryDto> GetCategory(int id, bool trackCkanges);
        Task AddBook(CategoryForCreationDto categorydto);
        Task EditBook(CategoryForUpdateDto categorydto);
        Task DeleteCategory(int id);
    }
}
