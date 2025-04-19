using AutoMapper;
using Entities.DataManipulationObject.CategoryDtos;
using Entities.DataManipulationObject.ProductDtos;
using Entities.Exceptions.CategoryExceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Models
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        private readonly ILoggerService _loggerService;
        public CategoryManager(IRepositoryManager manager, IMapper mapper, ILoggerService loggerManager)
        {
            _manager = manager;
            _mapper = mapper;
            _loggerService = loggerManager;
        }
        //Here we will manage the exceptions caused by the server
        public async Task CreateOneCategoryAsync(CategoryForCreationDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
             _manager.Category.CreateOneCategory(category);
            await _manager.SavesChangesAsync();
        }

        public async Task DeleteOneCategoryAsync(int id, bool trackChanges)
        {
            var category = await GetOneCategoryAndCheckExistAsync(id, trackChanges);
            _manager.Category.DeleteOneCategory(category);
            await _manager.SavesChangesAsync();
            string msg = "Category with Id:{id} has been deleted";
            _loggerService.LogInfo(msg);

        }
        private async Task<Category> GetOneCategoryAndCheckExistAsync(int id, bool trackChanges)
        {
            var category = await _manager.Category.GetCategoryByIdAsync(id, trackChanges)!;
            if (category is null)
            {
                string msg = $"Category with Id:{id} could not found";
                _loggerService.LogInfo(msg);
                throw new CategoryNotFoundException(id.ToString());
            }
               
            return category;
        }
        public async Task<(IEnumerable<ResultCategoryDto>categoryDtos,MetaData metaData)> GetAllCategoriesAsync(CategoryParameters categoryParameters,bool trackChanges)
        {
            var pagedResult= await _manager.Category.GetAllCategoriesAsync(categoryParameters,trackChanges);
            var categoryDto = _mapper.Map<IEnumerable<ResultCategoryDto>>(pagedResult);

            return (categoryDto, metaData: pagedResult.MetaData);

        }

        public async Task<ResultCategoryDto> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            var category= await GetOneCategoryAndCheckExistAsync(id, trackChanges);
            return _mapper.Map<ResultCategoryDto>(category);
        }
        
        public async Task UpdateOneCategoryAsync(int Id, CategoryForUpdateDto categoryDto, bool trackChanges)
        {
            var model = await GetOneCategoryAndCheckExistAsync(Id, trackChanges);
            model = _mapper.Map<Category>(categoryDto);
            _manager.Category.UpdateOneCategory(model);
            await _manager.SavesChangesAsync();
            string msg = $"Category with Id:{Id} has been updated";
            _loggerService.LogInfo(msg);
        }
    }
}
