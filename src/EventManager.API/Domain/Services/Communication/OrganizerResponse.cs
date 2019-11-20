using EventManager.API.Domain.Models;

namespace EventManager.API.Domain.Services.Communication
{
    public class OrganizerResponse : BaseResponse
    {
        public Organizer Organizer { get; private set;}

        private OrganizerResponse(bool success, string message, Organizer Organizer): base(success, message)
        {
            this.Organizer = Organizer;
        }

        public OrganizerResponse(Organizer Organizer) : this(true, string.Empty, Organizer)
        { }

        public OrganizerResponse(string message) : this(false, message, null)
        { }
    }
}