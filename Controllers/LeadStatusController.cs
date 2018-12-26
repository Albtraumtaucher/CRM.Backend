using System.Threading.Tasks;
using AutoMapper;
using CRM.API.Data;
using CRM.API.Dtos;
using CRM.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LeadStatusController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILeadRepository _repo;

        public LeadStatusController(IMapper mapper, ILeadRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetLeadStatuses()
        {
            var leadStatus = await _repo.GetLeadStatuses();

            return Ok(leadStatus);
        }

        [HttpGet("{id}", Name = "GetLeadStatus")]
        public async Task<IActionResult> GetLeadStatus(int id)
        {
            var leadStatus = await _repo.GetLeadStatus(id);

            return Ok(leadStatus);
        }

        [HttpPost]
        public async Task<IActionResult> NewLeadStatus(LeadStatus leadStatus)
        {
            var leadStatusToCreate = leadStatus;

            _repo.Add(leadStatus);

            var result = await _repo.SaveAll();

            if(result == true)
            {
                return CreatedAtRoute(routeName:"GetLead",
                    routeValues: new{ id = leadStatusToCreate.Id }, value: leadStatusToCreate);
            }

            return BadRequest("Couldn't save leadstatus");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditLeadStatus([FromQuery]int id, [FromBody]LeadStatusToUpdateDto leadStatusToUpdate)
        {
            var leadStatus = await _repo.GetLeadStatus(id);

            if(leadStatus == null)
            {
                return BadRequest("Couldn't find leadstatus");
            }

            _repo.Update(leadStatus);
            //Todo: Check if mapper updates in the right way
            leadStatus = _mapper.Map<LeadStatus>(leadStatusToUpdate);

            var result = await _repo.SaveAll();

            if(result == true)
            {
                var leadStatusToReturn = _mapper.Map<LeadStatusToReturnDto>(leadStatus);

                return Ok(leadStatusToReturn);
            }

            return BadRequest("Couldn't save changes for leadstatus");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeadStatus(int id)
        {
            var leadStatusToDelete = await _repo.GetLeadStatus(id);

            if(leadStatusToDelete == null)
                return NotFound();

            _repo.Delete(leadStatusToDelete);

            var result = await _repo.SaveAll();

            if(result == true)
            {
                return Ok("Deleted leadstatus successfully");
            }

            return BadRequest("Failed to delete leadstatus");
        }
    }
}