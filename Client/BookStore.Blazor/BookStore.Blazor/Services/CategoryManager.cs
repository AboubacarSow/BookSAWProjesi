using System.Text;
using BookStore.Blazor.Contracts;
using DTOs.CategoryDtos;
using Newtonsoft.Json;

namespace Services;
public class CategoryManager(IHttpClientFactory httpClientFactory) : ICategoryService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("BookStoreApi");
    public async Task<HttpResponseMessage> AddCategoryAsync(CategoryForCreationDto categorydto)
    {
        var jsonData = JsonConvert.SerializeObject(categorydto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("categories", content);
        return response;
    }
    public async Task<HttpResponseMessage> DeleteCategoryAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"categories/{id}");
        return response;
    }
    public async Task<HttpResponseMessage> EditCategoryAsync(CategoryForUpdateDto categorydto)
    {
        var jsonData = JsonConvert.SerializeObject(categorydto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"categories/{categorydto.CategoryId}", content);
        return response;
    }
    public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync(bool trackChanges)
    {
        var response = await _httpClient.GetAsync("categories");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Error while fetching categories from API");
        }
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return [];
        }
        var jsonData = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData) ?? [];
    }
    public async Task<ResultCategoryDto> GetCategoryAsync(int id, bool trackCkanges)
    {
        var response = await _httpClient.GetAsync($"categories/{id}");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Error while fetching category from API");
        }
        var jsonData = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<ResultCategoryDto>(jsonData) ?? new ResultCategoryDto();
    }
}
