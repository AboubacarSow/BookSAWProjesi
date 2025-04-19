using Entities.DataManipulationObject.CategoryDtos;
using Entities.Exceptions.CategoryExceptions;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionsFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/categories")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CategoriesController(IServiceManager manager, ILoggerService logger)
        {
            _manager = manager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories([FromQuery] CategoryParameters categoryParameters)
        {
            var (categoryDtos,metaData) = await _manager.CategoryService.GetAllCategoriesAsync(categoryParameters,false);
            Response.Headers["X-Pagination"] = JsonSerializer.Serialize(metaData);
            return Ok(categoryDtos);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneCategoryAsync([FromRoute(Name ="id")]int id)
        {
            var category=await _manager.CategoryService.GetOneCategoryByIdAsync(id,false);
            return Ok(category);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("createonecategory")]
        public async Task<IActionResult> CreateOneCategory([FromBody]CategoryForCreationDto categoryDto)
        {
            await _manager.CategoryService.CreateOneCategoryAsync(categoryDto);
            return Ok(new { StatusCode = 201, Message = $"One category item is successfully created " });
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneCategory([FromBody]CategoryForUpdateDto categoryDto,[FromRoute]int id)
        {
            if (id != categoryDto.CategoryId)
                throw new CategoryBadRequestException("Not match found with these two ID");
            await _manager.CategoryService.UpdateOneCategoryAsync(id,categoryDto,false);
            return Ok(new { StatusCode = 200, Message = $"Category with id:{id} has been udpated" });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneCategoryAsync([FromRoute] int id)
        {
            if (String.IsNullOrEmpty(id.ToString()))
                throw new CategoryBadRequestException($"the given id is null or empty");
            await _manager.CategoryService.DeleteOneCategoryAsync(id,true);
            return Ok(new {StatusCode=200, Message=$"Category with id:{id} has been deleted"});
        }


    }
}
