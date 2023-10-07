using AutoMapper;
using CapitalPlacementTask.Common;
using CapitalPlacementTask.Constants;
using CapitalPlacementTask.DTOs;
using CapitalPlacementTask.Interfaces;
using CapitalPlacementTask.IRepositories;
using CapitalPlacementTask.Models;

namespace CapitalPlacementTask.Services
{
    public class ProgramDetailService : IProgramDetailService
    {
        public readonly IProgramDetailRepository ProgramDetailRepository;
        private readonly IMapper Mapper;
        public ProgramDetailService(IProgramDetailRepository programDetailRepository, IMapper mapper)
        {
            ProgramDetailRepository = programDetailRepository ?? throw new ArgumentNullException(nameof(programDetailRepository));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<CreateResponse<ProgramDetail>> Create(ProgramDetailDTO request)
        {
            var response = new CreateResponse<ProgramDetail> { Success = false };
            request.ProgramTitle = request.ProgramTitle.Trim();
            request.ProgramSummary = request.ProgramSummary?.Trim();
            request.ProgramDescription = request.ProgramDescription.Trim();
            request.ProgramBenefits = request.ProgramBenefits?.Trim();
            request.ApplicationCriteria = request.ApplicationCriteria?.Trim();
            request.Duration = request.Duration?.Trim();
            request.ProgramLocation = request.ProgramLocation.Trim();

            #region Check if ProgramDetail exist
            var programDetail = await ProgramDetailRepository.GetFirstOrDefault(x => x.ProgramTitle == request.ProgramTitle);
            if (programDetail is not null)
            {
                response.ErrorReason = ErrorConstants.PROGRAM_DETAIL_EXISTS;
                return response;
            }
            #endregion
            #region Check if the skills needed contains duplicate value
            if (HasDuplicates(request.SkillsNeeded))
            {
                response.ErrorReason = ErrorConstants.PROGRAM_DETAIL_Skill_NEEDED;
                return response;
            }
            #endregion
            #region Insert ProgramDetail record
            programDetail = Mapper.Map<ProgramDetail>(request);
            programDetail.CreatedDate = DateTime.UtcNow;
            programDetail.LastModifiedDate = DateTime.UtcNow;

            var data = await ProgramDetailRepository.Insert(programDetail);
            if (data is null)
            {
                response.ErrorReason = ErrorConstants.INSERT_PROGRAM_DETAIL_FAILED;
                return response;
            }
            #endregion

            response.Data = data;
            response.Success = true;
            return response;
        }

        public async Task<List<ProgramDetail>> GetAll()
        {
            return await ProgramDetailRepository.GetAll();
        }

        public async Task<ProgramDetail> GetById(Guid id)
        {
            return await ProgramDetailRepository.GetById(id);
        }

        public async Task<CreateResponse<ProgramDetail>> Update(ProgramDetailDTO request, Guid id)
        {
            var response = new CreateResponse<ProgramDetail> { Success = false };
            request.ProgramTitle = request.ProgramTitle.Trim();
            request.ProgramSummary = request.ProgramSummary?.Trim();
            request.ProgramDescription = request.ProgramDescription.Trim();
            request.ProgramBenefits = request.ProgramBenefits?.Trim();
            request.ApplicationCriteria = request.ApplicationCriteria?.Trim();
            request.Duration = request.Duration?.Trim();
            request.ProgramLocation = request.ProgramLocation.Trim();

            #region Check if ProgramDetail exist
            var programDetail = await ProgramDetailRepository.GetById(id);
            if (programDetail is null)
            {
                response.ErrorReason = ErrorConstants.PROGRAM_DETAIL_DOSE_NOT_EXISTS;
                return response;
            }
            #endregion

            #region Check if the skills needed contains duplicate value
            if (HasDuplicates(request.SkillsNeeded))
            {
                response.ErrorReason = ErrorConstants.PROGRAM_DETAIL_Skill_NEEDED;
                return response;
            }
            #endregion

            #region Check if ProgramDetail with ProgramTitle exists
            var checkTitleExist = await ProgramDetailRepository
                .GetFirstOrDefault(x => x.ProgramTitle == request.ProgramTitle && x.Id != id);
            if (checkTitleExist is not null)
            {
                response.ErrorReason = ErrorConstants.PROGRAM_DETAIL_EXISTS;
                return response;
            }
            #endregion

            #region Update program detail record
            var detail = Mapper.Map<ProgramDetail>(request);
            detail.CreatedDate = programDetail!.CreatedDate;
            detail.IsDeleted = programDetail.IsDeleted;
            detail.Id = programDetail.Id;
            detail.LastModifiedDate = DateTime.UtcNow;

            var data = await ProgramDetailRepository.Update(programDetail);
            if (data is null)
            {
                response.ErrorReason = ErrorConstants.UPDATE_PROGRAM_DETAIL_FAILED;
                return response;
            }
            #endregion

            response.Data = data;
            response.Success = true;
            return response;
        }
        public static bool HasDuplicates(List<string>? skillsNeeded)
        {
            // Check for null or empty list
            if (skillsNeeded == null || !skillsNeeded.Any())
            {
                return false; // No duplicates in an empty list or null list
            }

            // Use LINQ to count distinct items and compare with the total count
            int distinctCount = skillsNeeded.Select(x => x.ToLower()).Distinct().Count();
            int totalCount = skillsNeeded.Count;

            return distinctCount != totalCount; // If counts are not equal, there are duplicates
        }
    }
}
