using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts
{
    public interface ICategoryRepository
    {
        Task<PagedList<Category>> GetAllCategoriesAsync(CategoryParameters categoryParameters,bool trackChanges);
        Task<Category>? GetCategoryByIdAsync(int id, bool trackChanges);
        void CreateOneCategory(Category category);
        void UpdateOneCategory(Category category);
        void DeleteOneCategory(Category category);


    }
}
