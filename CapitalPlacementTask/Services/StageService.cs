using AutoMapper;
using CapitalPlacementTask.Common;
using CapitalPlacementTask.Constants;
using CapitalPlacementTask.DTOs;
using CapitalPlacementTask.Interfaces;
using CapitalPlacementTask.IRepositories;
using CapitalPlacementTask.Models;

namespace CapitalPlacementTask.Services
{
    public class StageService : IStageService
    {
        private readonly IProgramDetailRepository ProgramDetailRepository;
        private readonly IMapper Mapper;

        public StageService(IProgramDetailRepository programDetailRepository, IMapper mapper)
        {
            ProgramDetailRepository = programDetailRepository ?? throw new ArgumentNullException(nameof(programDetailRepository));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<Stage>?> GetByProgramDetailId(Guid programDetailId)
        {
            var programDetail = await ProgramDetailRepository.GetFirstOrDefault(x => x.Id == programDetailId);
            return programDetail.Stages;
        }

        public async Task<CreateResponse<List<Stage>>> Update(List<StageDTO> request, Guid programDetailId)
        {
            var response = new CreateResponse<List<Stage>> { Success = false };

            #region Check if ProgramDetail exists
            var programDetail = await ProgramDetailRepository.GetById(programDetailId);
            if (programDetail == null)
            {
                response.ErrorReason = ErrorConstants.PROGRAM_DETAIL_DOSE_NOT_EXISTS;
                return response;
            }
            #endregion

            #region save stages
            var stages = Mapper.Map<List<Stage>>(request);

            programDetail.Stages = stages;

            var updatedProgramDetail = await ProgramDetailRepository.Update(programDetail);
            if (updatedProgramDetail == null)
            {
                response.ErrorReason = ErrorConstants.UPDATE_PROGRAM_DETAIL_FAILED;
                return response;
            }
            #endregion

            response.Data = stages;
            response.Success = true;
            return response;
        }
    }
}

