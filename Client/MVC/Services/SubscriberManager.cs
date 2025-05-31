using MVC.Contracts;
using MVC.DTOs.SubscriberDtos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MVC.Services
{
    public class SubscriberManager(IHttpClientFactory httpClientFactory) : ISubscriberService
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("BookStoreApi");

        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"subscribers/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<ResultSubscriberDto>> GetAll()
        {
            var response = await _httpClient.GetAsync("subscribers");
            if (response.IsSuccessStatusCode)
            {
                var jsonData=await response.Content.ReadAsStringAsync();
                var subscribers= JsonConvert.DeserializeObject<List<ResultSubscriberDto>>(jsonData);
                return subscribers;
            }
            return [] ;
        }

        public async Task<ResultSubscriberDto> GetOne(int id)
        {
            var response = await _httpClient.GetAsync("subscriber");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var subscriber = JsonConvert.DeserializeObject<ResultSubscriberDto>(jsonData);
                return subscriber;
            }
            return new();
        }

        public async Task<bool> Subscribe(CreateSubscriberDto createSubscriberDto)
        {
            var jsonData=JsonConvert.SerializeObject(createSubscriberDto);
            var content= new StringContent(jsonData,Encoding.UTF8,"application/json");
            var request = await _httpClient.PostAsync("subscribers", content);
            return request.IsSuccessStatusCode;
        }
    }
}
