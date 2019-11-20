using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections;
using EventManager.API.Domain.Services;
using EventManager.API.Resources;
using EventManager.API.Mapping;
using EventManager.API.Domain.Models;
using EventManager.API.Extensions;

namespace EventManager.API.Controllers
{
    [Route("/api/[controller]")]
    public class OrganizersController: Controller
    {
        private readonly IOrganizerService _organizerService;
        private readonly IMapper _mapper;
        private readonly ILogger<OrganizersController> _logger;

        public OrganizersController(IOrganizerService organizerService, IMapper mapper, ILogger<OrganizersController> logger)
        {
            this._organizerService = organizerService;
            this._mapper = mapper;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable> Get()
        {
           return await this._organizerService.ListAsync();
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] OrganizerResource resource)
        {
           if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
           
           var organzier =_mapper.Map<OrganizerResource, Organizer>(resource);
           var result = await _organizerService.SaveAsync(organzier);

           if(!result.Success)
                return BadRequest(result.Message);
            
            var organizerResource = _mapper.Map<Organizer, OrganizerResource>(result.Organizer);

            return Ok(organizerResource);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] OrganizerResource resources)
        {
            if(!ModelState.IsValid)
                 return BadRequest(ModelState.GetErrorMessages());
            
            var organizer = _mapper.Map<OrganizerResource, Organizer>(resources);
            var result = await _organizerService.UpdateAsync(id, organizer);

           if(!result.Success)
                return BadRequest(result.Message);
            
            var organizerResource = _mapper.Map<Organizer, OrganizerResource>(result.Organizer);


            return Ok(organizerResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _organizerService.DeleteAsync(id);

            if(!result.Success)
                return BadRequest(result.Message);
            
            var organizerResource = _mapper.Map<Organizer, OrganizerResource>(result.Organizer);

            return Ok(organizerResource);
        }
    }
}