using CapitalPlacementTask.Common;
using CapitalPlacementTask.DTOs;
using CapitalPlacementTask.Models;

namespace CapitalPlacementTask.Interfaces
{
    public interface IStageService
    {
        Task<List<Stage>?> GetByProgramDetailId(Guid programDetailId);
        Task<CreateResponse<List<Stage>>> Update(List<StageDTO> request, Guid programDetailId);
    }
}
