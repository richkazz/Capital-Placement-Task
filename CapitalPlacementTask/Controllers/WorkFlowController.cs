using CapitalPlacementTask.Common;
using CapitalPlacementTask.DTOs;
using CapitalPlacementTask.Interfaces;
using CapitalPlacementTask.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CapitalPlacementTask.Controllers
{
    [Route("api/WorkFlow")]
    [ApiController]
    public class WorkFlowController : ControllerBase
    {
        private readonly IStageService StageService;

        public WorkFlowController(IStageService stageService)
        {
            StageService = stageService;
        }

        [HttpGet("{programDetailId}")]
        [ProducesResponseType(typeof(Stage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(Guid programDetailId)
        {
            var stage = await StageService.GetByProgramDetailId(programDetailId);
            return Ok(stage);
        }

        [HttpPut("{programDetailId}")]
        [ProducesResponseType(typeof(CreateResponse<List<StageDTO>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(Guid programDetailId, [FromBody] List<StageDTO> request)
        {
            var response = await StageService.Update(request, programDetailId);
            return Ok(response);
        }
    }
}
