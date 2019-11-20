using System.Collections.Generic;

namespace EventManager.API.Domain.Models 
{
    public class Organizer
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Email {get; set;}
        public string Location {get; set;}
        public string Web {get; set;}

        public IList<Event> Events {get; set;} = new List<Event>();
    }

}