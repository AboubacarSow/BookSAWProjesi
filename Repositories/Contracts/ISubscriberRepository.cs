using Entities.Models;

namespace Repositories.Contracts
{
    public interface ISubscriberRepository
    {
        Task<List<Subscriber>> GetAllSubscribersAsync(bool trackChanges);
        Task<Subscriber>? GetSubscriberAsync(int id, bool trackChanges);
        void CreateOneSubscriber(Subscriber subscriber);
        void DeleteOneSubscriber(Subscriber subscriber);
    }
}
