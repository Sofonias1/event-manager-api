using EventManager.API.Domain.Models;

namespace EventManager.API.Domain.Services.Communication
{
    public class EventResponse : BaseResponse
    {
        public Event Event { get; private set;}

        private EventResponse(bool success, string message, Event events): base(success, message)
        {
            this.Event = events;
        }
        
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="events">Saved Event.</param>
        /// <returns>Response.</returns>
        public EventResponse(Event events) : this(true, string.Empty, events)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public EventResponse(string message) : this(false, message, null)
        { }

        public EventResponse(): this(false,string.Empty,null)
        {}
    }
}