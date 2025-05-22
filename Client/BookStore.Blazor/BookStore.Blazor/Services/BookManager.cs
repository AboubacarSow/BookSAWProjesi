using System.Text;
using BookStore.Blazor.Contracts;
using DTOs.BookDtos;
using Newtonsoft.Json;

namespace Services;
public class BookManager(IHttpClientFactory httpClientFactory) : IBookService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("BookStoreApi");

    public async Task<HttpResponseMessage> AddBookAsync(CreateBookDto bookdto)
    {
        var jsonData = JsonConvert.SerializeObject(bookdto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("books/CreateOneBook", content);
        return response;
    }
    public async Task<HttpResponseMessage> DeleteBookAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"books/{id}");
        return response;
    }
    public async Task<HttpResponseMessage> EditBookAsync(UpdateBookDto bookdto)
    {
        var jsonData = JsonConvert.SerializeObject(bookdto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"books/{bookdto.Id}", content);
        return response;
    }
    public async Task<List<ResultBookDto>> GetAllBooksAsync()
    {
        var response = await _httpClient.GetAsync("books");
       if(!response.IsSuccessStatusCode)
        {
            throw new Exception("Error while fetching books from API");
        }
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return [];
        }
        var jsonData = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<ResultBookDto>>(jsonData) ?? new List<ResultBookDto>();
        
    }
    public async Task<List<BannerBookDto>> GetBannerBookDtosAsync()
    {
        var response = await _httpClient.GetAsync("books/banners");
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return [];
        var jsonData = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<BannerBookDto>>(jsonData)!;
    }

    public async Task<ResultBookDto> GetBookAsync(int id)
    {
       var response = await _httpClient.GetAsync($"books/{id}");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Error while fetching book from API");
        }
        var jsonData = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<ResultBookDto>(jsonData) ?? new ResultBookDto();
    }
}