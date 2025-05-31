using MVC.DTOs.SubscriberDtos;

namespace MVC.Contracts
{
    public interface ISubscriberService
    {
        Task<List<ResultSubscriberDto>> GetAll();
        Task<ResultSubscriberDto> GetOne(int id);   
        Task<bool> Delete(int id);
        Task<bool> Subscribe(CreateSubscriberDto createSubscriberDto);

    }
}
