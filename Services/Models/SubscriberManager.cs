using AutoMapper;
using Entities.DataManipulationObject.SubscriberDtos;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Models;

public class SubscriberManager : ISubscriberService
{
    private readonly IRepositoryManager _repository;
    private IMapper _mapper;
    public SubscriberManager(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task CreateOneSubscriberAsync(CreateSubscriberDto subscriberDto)
    {
        var subscriber=_mapper.Map<Subscriber>(subscriberDto);
         _repository.Subscriber.CreateOneSubscriber(subscriber);
        await _repository.SavesChangesAsync();
    }

    public async Task DeleteOneSubscriberAsync(int id, bool trackChanges)
    {
        var subscriber=await _repository.Subscriber.GetSubscriberAsync(id, trackChanges);   
        if(subscriber != null)
        {
            _repository.Subscriber.DeleteOneSubscriber(subscriber);
            await _repository.SavesChangesAsync();
            return;
        }

    }

    public async Task<List<ResultSubscriberDto>> GetAllSubscriberAsync(bool trackChanges)
    {
        var subscribers = await _repository.Subscriber.GetAllSubscribersAsync(trackChanges);
        return _mapper.Map<List<ResultSubscriberDto>>(subscribers); 
    }

    public async Task<ResultSubscriberDto> GetOneSubscriberByIdAsync(int id, bool trackChanges)
    {
        var subscriber = await _repository.Subscriber.GetSubscriberAsync(id, trackChanges);
        return _mapper.Map<ResultSubscriberDto>(subscriber);
    }
}
