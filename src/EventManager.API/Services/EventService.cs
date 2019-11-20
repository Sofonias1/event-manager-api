using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using EventManager.API.Domain.Services;
using EventManager.API.Domain.Models;
using EventManager.API.Domain.Repositories;
using EventManager.API.Domain.Services.Communication;
using EventManager.API.Persistence.Repositories;

namespace EventManager.API.Services
{
    public class EventService: IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EventService(IEventRepository eventRepository, IUnitOfWork unitOfWork)
        {
            this._eventRepository = eventRepository;
            this._unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Event>> ListAsync()
        {
            return await this._eventRepository.ListAsync();

        }

        public async Task<EventResponse> SaveAsync(Event events)
        {
            try
            {
                await this._eventRepository.AddAsync(events);
                await this._unitOfWork.CompleteAsync();

                return new EventResponse(events);
            }
            catch(Exception ex)
            {
                return new EventResponse($"An error occurred when saving the Event: {ex.Message}");
            }
        }

        public async Task<EventResponse> UpdateAsync(int id, Event events)
        {
            var existingEvent = await this._eventRepository.FindByIdAsync(id);
            if(existingEvent == null)
               return new EventResponse("Event not found.");
            
            // TODO: Update all the necessary properties
            existingEvent.Address = events.Address;
            existingEvent.City = events.Address;
            existingEvent.Description = events.Description;
            existingEvent.Title = events.Title;
            existingEvent.StartTimeInUTC = events.StartTimeInUTC;

            try
            {
              this._eventRepository.Update(existingEvent);
              await this._unitOfWork.CompleteAsync();

              return new EventResponse(existingEvent);

            }
            catch(Exception ex)
            {
              return new EventResponse($"An error occured while saving the event {ex.Message}");
            }
        }
        
        public async Task<EventResponse> DeleteAsync(int id)
        {
            var existingEvent = await _eventRepository.FindByIdAsync(id);

            if(existingEvent == null)
                return new EventResponse("Event not found");
            
            try
            {
               _eventRepository.Remove(existingEvent);
               await _unitOfWork.CompleteAsync();

               return new EventResponse(existingEvent);
            }
            catch(Exception ex)
            {
                return new EventResponse($"An error occured while deleting the event {ex.Message}");
            }
        }
    }
}