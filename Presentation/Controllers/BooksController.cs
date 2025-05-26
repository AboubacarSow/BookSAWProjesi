using Entities.DataManipulationObject.ProductDtos;
using Entities.Exceptions.ProductExceptions;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionsFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    public class BooksController(IServiceManager service) : ControllerBase
    {
        private readonly IServiceManager _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllBooks([FromQuery]BookParameters bookParameters)
        {
            var (bookDtos, metaData) = await _service.BookService.GetAllBooksAsync(bookParameters,false);
            Response.Headers["X-Pagination"] = JsonSerializer.Serialize(metaData);
            
            return Ok(bookDtos);
        }

        [HttpGet("banners")]
        public async Task<IActionResult> GetBookBannersAsync()
        {
            return Ok(await _service.BookService.GetAllBookBannerAsync(false));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBook([FromRoute]int id)
        {
            if (String.IsNullOrEmpty(id.ToString()))
                throw new BookBadRequestException($"The given id is null or empty");
            var model = await _service.BookService.GetOneBookByIdAsync(id, false);
            return Ok(model);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("CreateOneBook")]
        public async Task<IActionResult> CreateOneBook([FromBody] CreateBookDto bookDto)
        {
            await _service.BookService.CreateOneBookAsync(bookDto);
            return Ok(new { StatusCode = 201, Message = $"One Book item is successfully created successfully" });

        }
        [HttpDelete("{id:int}")]
        public  async Task<IActionResult> DeleteOneBook([FromRoute] int id)
        {
            await _service.BookService.DeleteOneBookAsync(id, true);
            return Ok(new { StatusCode = 200, Message = $"Book item with ID:{id} is deleted successfully" });
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneBook([FromRoute]int id, [FromBody]UpdateBookDto bookDto)
        {
            var model=await _service.BookService.UpdateOneBookAsync(id, bookDto, false);
            return Ok(new { StatusCode = 200, Message = $"Book item with ID:{id} is successfully updated",Book= model});
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PartiallyUpdateOneBook([FromRoute]int id, [FromBody]
        JsonPatchDocument<UpdateBookDto> bookPatch)
        {
            if (bookPatch is null)
                throw new BookBadRequestException("The given item is null");
            var (bookUpdateDto, book) = await _service.BookService.GetOneBookForPatchAsync(id, true);
            //Pour que ModelState soit accepter comme second parametre il nous faut le package le package NewtonsoftJson
            bookPatch.ApplyTo(bookUpdateDto,ModelState);
            TryValidateModel(bookUpdateDto);
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            await _service.CategoryService.GetOneCategoryByIdAsync(bookUpdateDto.CategoryId,false);
            await _service.BookService.SaveChangesForPathAsync(bookUpdateDto,book);
            return NoContent();
        }

        [HttpOptions]
        public IActionResult GetOptions()
        {
            Response.Headers.Allow = "GET,POST,PUT,PATCH,DELETE,OPTIONS";
            return Ok();
        }

    }
}
