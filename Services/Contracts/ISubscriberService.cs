using Entities.DataManipulationObject.SubscriberDtos;
using Entities.RequestFeatures;

namespace Services.Contracts;
public interface ISubscriberService
{
    Task<List<ResultSubscriberDto>> GetAllSubscriberAsync(bool trackChanges);
    Task<ResultSubscriberDto> GetOneSubscriberByIdAsync(int id, bool trackChanges);
    Task CreateOneSubscriberAsync(CreateSubscriberDto subscriberDto);
    Task DeleteOneSubscriberAsync(int id, bool trackChanges);
}
