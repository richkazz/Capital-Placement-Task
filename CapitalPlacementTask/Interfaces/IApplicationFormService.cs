using CapitalPlacementTask.Common;
using CapitalPlacementTask.DTOs;
using CapitalPlacementTask.Models;

namespace CapitalPlacementTask.Interfaces
{
    public interface IApplicationFormService
    {
        Task<ApplicationForm?> GetByProgramDetailId(Guid programDetailId);
        Task<CreateResponse<ApplicationForm>> Update(Guid programDetailId, ApplicationFormDTO request);
    }
}
