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
    public class ProgramDetailController : ControllerBase
    {
        private readonly IProgramDetailService ProgramDetailService;
        public ProgramDetailController(IProgramDetailService programDetailService)
        {
            ProgramDetailService = programDetailService;
        }
        //// GET: api/<ProgramDetailController>
        //[HttpGet]
        //[ProducesResponseType(typeof(List<ProgramDetail>), (int)HttpStatusCode.OK)]
        //public async Task<IActionResult> Get()
        //{
        //    return Ok(await ProgramDetailService.GetAll());
        //}

        // GET api/<ProgramDetailController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProgramDetail), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await ProgramDetailService.GetById(id));
        }

        // POST api/<ProgramDetailController>
        [HttpPost]
        [ProducesResponseType(typeof(CreateResponse<ProgramDetail>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] ProgramDetailDTO resut)
        {
            return Ok(await ProgramDetailService.Create(resut));
        }

        // PUT api/<ProgramDetailController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CreateResponse<ProgramDetail>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProgramDetailDTO resut)
        {
            return Ok(await ProgramDetailService.Update(resut, id));
        }
    }
}
