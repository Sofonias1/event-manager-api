using EventManager.API.Enums;
using System;
///https://www.freecodecamp.org/news/an-awesome-guide-on-how-to-build-restful-apis-with-asp-net-core-87b818123e28/
namespace EventManager.API.Domain.Models 
{
    public class Event
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string Description {get; set;}
        public string LocationName {get; set;}
        public string Address {get; set;}
        public string City {get; set;}
        public string Country {get; set;}
        public string StartTimeInUTC {get; set;}
        public string EndTimeInUTC {get; set;}
        public EventTypes Type {get; set;}

        public int OrganizerId {get; set;}
        public Organizer organizer {get; set;}
    }

}