using AutoMapper;
using EventManager.API.Domain.Models;
using EventManager.API.Resources;

namespace EventManager.API.Mapping
{
    public class ResourceToModelProfile: Profile
    {
        public ResourceToModelProfile()
        {
           CreateMap<EventResource, Event>();
           CreateMap<OrganizerResource, Organizer>();
        }
    }
}