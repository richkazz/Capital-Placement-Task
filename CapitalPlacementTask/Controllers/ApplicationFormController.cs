using CapitalPlacementTask.Common;
using CapitalPlacementTask.DTOs;
using CapitalPlacementTask.Interfaces;
using CapitalPlacementTask.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CapitalPlacementTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {
        private readonly IApplicationFormService ApplicationFormService;

        public ApplicationFormController(IApplicationFormService applicationFormService)
        {
            ApplicationFormService = applicationFormService;
        }

        [HttpGet("{programDetailId}")]
        [ProducesResponseType(typeof(ApplicationForm), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(Guid programDetailId)
        {
            var applicationForm = await ApplicationFormService.GetByProgramDetailId(programDetailId);
            return Ok(applicationForm);
        }
        [HttpPut("{programDetailId}")]
        [ProducesResponseType(typeof(CreateResponse<ApplicationForm>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(Guid programDetailId, [FromBody] ApplicationFormDTO applicationFormDTO)
        {
            var applicationForm = await ApplicationFormService.Update(programDetailId, applicationFormDTO);
            return Ok(applicationForm);
        }

    }

}
