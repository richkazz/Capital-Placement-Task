using CapitalPlacementTask.Interfaces;
using CapitalPlacementTask.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CapitalPlacementTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreviewController : ControllerBase
    {
        private readonly IProgramDetailService ProgramDetailService;
        public PreviewController(IProgramDetailService programDetailService)
        {
            ProgramDetailService = programDetailService;
        }

        // GET api/<ProgramDetailController>/5
        [HttpGet("{programDetailId}")]
        [ProducesResponseType(typeof(ProgramDetail), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(Guid programDetailId)
        {
            return Ok(await ProgramDetailService.GetById(programDetailId));
        }
    }
}
