using System.Threading.Tasks;
using System.Collections.Generic;
using System;

using EventManager.API.Domain.Services;
using EventManager.API.Domain.Models;
using EventManager.API.Domain.Repositories;
using EventManager.API.Domain.Services.Communication;

namespace EventManager.API.Services
{
    public class OrganizerService: IOrganizerService
    {
         private readonly IOrganizerRepository _organizerRepository;
         private readonly IUnitOfWork _unitOfWork;

         public OrganizerService(IOrganizerRepository organizerRepository, IUnitOfWork unitOfWork)
         {
            this._organizerRepository = organizerRepository;
            this._unitOfWork = unitOfWork;
         }
        public async Task<IEnumerable<Organizer>> ListAsync()
        {
            return await this._organizerRepository.ListAsync();
        }
        
        public async Task<OrganizerResponse> SaveAsync(Organizer organizer)
        {
            try
            {
              await this._organizerRepository.AddAsync(organizer);
              await this._unitOfWork.CompleteAsync();

              return new OrganizerResponse(organizer);
            }
            catch(Exception ex)
            {
              // Do some logging stuff
			   return new OrganizerResponse($"An error occurred when saving the Organizer: {ex.Message}");
            }
        }

        public async Task<OrganizerResponse> UpdateAsync(int id, Organizer organizer)
        {
            var existingOrganizer = await this._organizerRepository.FindByIdAsync(id);
            if(existingOrganizer == null)
                return new OrganizerResponse("Organizer not found.");

            // TODO: Update all the necessary properties
            existingOrganizer.Web = organizer.Web;
            existingOrganizer.Name = organizer.Name;
            existingOrganizer.Location = organizer.Location;

            try
            {
                 _organizerRepository.Update(existingOrganizer);
                 await _unitOfWork.CompleteAsync();

                 return new OrganizerResponse(existingOrganizer);
            }
            catch(Exception ex)
            {
              // Do some logging stuff
			   return new OrganizerResponse($"An error occurred when saving the Organizer: {ex.Message}");

            }
        }

        public async Task<OrganizerResponse> DeleteAsync(int id)
        {
            var existingOrganizer = await _organizerRepository.FindByIdAsync(id);

            if(existingOrganizer == null)
                return new OrganizerResponse("Organizer not found");
            
            try
            {
               _organizerRepository.Remove(existingOrganizer);
               await _unitOfWork.CompleteAsync();

               return new OrganizerResponse(existingOrganizer);
            }
            catch(Exception ex)
            {
                return new OrganizerResponse($"An error occured when deleting the Organizer: {ex.Message}");
            }
        }
    }
}