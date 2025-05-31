using AutoMapper;
using Entities.DataManipulationObject.SubscriberDtos;
using Entities.Models;

namespace Services.AutoMapper
{
    public  class SubscriberMapper:Profile
    {
        public SubscriberMapper()
        {
            CreateMap<Subscriber, ResultSubscriberDto>();
            CreateMap<CreateSubscriberDto, Subscriber>();
        }
    }
}
