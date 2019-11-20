using System.ComponentModel.DataAnnotations;

namespace EventManager.API.Resources
{
    public class EventResource
    {
        [Required]
        [MaxLength(40)]
        public string Title {get; set;}
        [Required]
        public string Description {get; set;}
        [Required]
        public string LocationName {get; set;}
        public string Address {get; set;}
        public string City {get; set;}
        public string Country {get; set;}
        [Required]
        public string StartTimeInUTC {get; set;}
        public string EndTimeInUTC {get; set;}
        public OrganizerResource Organizer {get; set;}
        public string Type {get; set;}
    }
}