using System.ComponentModel.DataAnnotations;

namespace EventManager.API.Resources 
{
    public class OrganizerResource
    {
        [Required]
        [MaxLength(40)]
        public string Name {get; set;}
        [Required]
        public string Email {get; set;}
        [Required]
        public string Location {get; set;}
        public string Web {get; set;}
    }

}