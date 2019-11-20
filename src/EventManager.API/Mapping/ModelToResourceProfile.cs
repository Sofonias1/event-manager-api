using AutoMapper;
using EventManager.API.Domain.Models;
using EventManager.API.Resources;

namespace EventManager.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
             CreateMap<Event, EventResource>()
                 .ForMember(src => src.Type,
                             opt => opt.MapFrom(src => src.Type));
             CreateMap<Organizer, OrganizerResource>();
        }
    }
}