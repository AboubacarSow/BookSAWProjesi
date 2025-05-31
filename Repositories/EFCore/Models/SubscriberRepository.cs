using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Context;
using System.Reflection.Metadata.Ecma335;

namespace Repositories.EFCore.Models;

public class SubscriberRepository : RepositoryBase<Subscriber>, ISubscriberRepository
{
    public SubscriberRepository(RepositoryContext context) : base(context)
    {
    }

    public void CreateOneSubscriber(Subscriber subscriber)=>Add(subscriber);
    

    public void DeleteOneSubscriber(Subscriber subscriber)=>Remove(subscriber);


    public async Task<List<Subscriber>> GetAllSubscribersAsync(bool trackChanges)
        => await FindAll(trackChanges).ToListAsync();
    

    public async Task<Subscriber>? GetSubscriberAsync(int id, bool trackChanges)
   =>await FindByCondition(b=>b.Id==id,trackChanges).FirstOrDefaultAsync();
}
