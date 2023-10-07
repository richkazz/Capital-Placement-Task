using CapitalPlacementTask.Common;
using CapitalPlacementTask.DTOs;
using CapitalPlacementTask.Models;

namespace CapitalPlacementTask.Interfaces
{
    public interface IProgramDetailService
    {
        public Task<CreateResponse<ProgramDetail>> Create(ProgramDetailDTO request);
        public Task<CreateResponse<ProgramDetail>> Update(ProgramDetailDTO request, Guid id);
        public Task<ProgramDetail> GetById(Guid id);
        public Task<List<ProgramDetail>> GetAll();
    }
}
