using AutoMapper;
using Contracts;
using DTOs.BookDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Controllers;

public class BookController : Controller
{
    private readonly IServiceManager _manager;
    private readonly IMapper _mapper;
    public BookController(IServiceManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }
    public async Task<IActionResult> Index()
    {
        var books= await _manager.BookService.GetAllBooksAsync();
        return View(books);
    }
    [HttpGet]
    public async Task<IActionResult> AddBook()
    {
        await GetCategory();
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddBook(CreateBookDto bookDto)
    {
        var result = await _manager.BookService.AddBookAsync(bookDto);
        if (result.IsSuccessStatusCode)
            return RedirectToAction(nameof(Index));
        await GetCategory();
        return View(bookDto);
    }

    private async Task GetCategory()
    {
        var categories = await _manager.CategoryService.GetAllCategoriesAsync();
        ViewBag.Categories = (from c in categories
                              select new SelectListItem
                              {
                                  Text = c.CategoryName,
                                  Value = c.CategoryId.ToString()
                              }).ToList();
    }
    [HttpGet]
    public async Task<IActionResult> EditBook([FromRoute]int Id)
    {
        var book=await _manager.BookService.GetBookAsync(Id);
        var resultBookDto=_mapper.Map<UpdateBookDto>(book);
        await GetCategory();
        return View(resultBookDto);
    }
    [HttpPost]
    public async Task<IActionResult> EditBook(UpdateBookDto bookDto)
    {
        var result=await _manager.BookService.EditBookAsync(bookDto);
        if (!result.IsSuccessStatusCode)
        {
            await GetCategory();
            return View(bookDto);
        }
        return RedirectToAction($"{nameof(Index)}");
    }
    public async Task<IActionResult> DeleteBook([FromRoute]int id)
    {
        var result =await _manager.BookService.DeleteBookAsync(id);
       return RedirectToAction($"{nameof(Index)}");
    }
}
