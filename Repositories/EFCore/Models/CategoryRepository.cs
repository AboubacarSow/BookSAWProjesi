using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Repositories.Contracts;
using Repositories.EFCore.Context;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore.Models
{
    public class CategoryRepository(RepositoryContext context) :
        RepositoryBase<Category>(context), ICategoryRepository
    {
        public void CreateOneCategory(Category category) => Add(category);
        public void DeleteOneCategory(Category category) => Remove(category);
        public async Task<PagedList<Category>> GetAllCategoriesAsync(CategoryParameters categoryParameters,bool trackChanges)
        {
            var source=await FindAll(trackChanges)
                            .Search(categoryParameters.SearchTerm)
                            .Sort(categoryParameters.OrderByString)
                            .ToListAsync();
            return PagedList<Category>
                .ToPagedList(source, categoryParameters.PageNumber, categoryParameters.PageSize);

        }
        public async Task<Category>? GetCategoryByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(c => c.CategoryId.Equals(id), trackChanges).FirstOrDefaultAsync();
        public void UpdateOneCategory(Category category) => Edit(category);
        
    }
}
