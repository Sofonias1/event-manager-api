using System.ComponentModel;

namespace EventManager.API.Enums
{
    public enum EventTypes
    {
        [Description("Socials")]
        Socials ,
        [Description("Classes")]
        Classes ,
        [Description("Festivals")]
        Festivals,
        [Description("Sports")]
        Sports ,
        [Description("Movies")]
        Movies ,
        [Description("Parties")]
        Parties  
    }

}