using AutoMapper;
using CapitalPlacementTask.Common;
using CapitalPlacementTask.Constants;
using CapitalPlacementTask.DTOs;
using CapitalPlacementTask.Enums;
using CapitalPlacementTask.Interfaces;
using CapitalPlacementTask.IRepositories;
using CapitalPlacementTask.Models;

namespace CapitalPlacementTask.Services
{
    public class ApplicationFormService : IApplicationFormService
    {
        public readonly IProgramDetailRepository ProgramDetailRepository;
        private readonly IMapper Mapper;
        public ApplicationFormService(IProgramDetailRepository programDetailRepository, IMapper mapper)
        {
            ProgramDetailRepository = programDetailRepository ?? throw new ArgumentNullException(nameof(programDetailRepository));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<ApplicationForm?> GetByProgramDetailId(Guid programDetailId)
        {
            var programDetail = await ProgramDetailRepository.GetById(programDetailId);
            return programDetail?.ApplicationForm;
        }

        static CreateResponse<ApplicationForm> CheckIfAppFromQuestionIsValid(List<ApplicationFormQuestion> applicationFormQuestions)
        {
            var response = new CreateResponse<ApplicationForm> { Success = false };
            foreach (var item in applicationFormQuestions)
            {
                switch (item.Type)
                {
                    case QuestionType.MultipleChoice:
                        if (item.ApplicationFormQuestionMultipleChoice == null)
                        {
                            response.ErrorReason = "Invalid ApplicationFormQuestionMultipleChoice";
                            return response;
                        }
                        break;
                    case QuestionType.YesOrNo:
                        if (item.ApplicationFormQuestionYesOrNo == null)
                        {
                            response.ErrorReason = "Invalid ApplicationFormQuestionYesOrNo";
                            return response;
                        }
                        break;
                }
            }
            response.Success = true;
            return response;
        }
        public async Task<CreateResponse<ApplicationForm>> Update(Guid programDetailId, ApplicationFormDTO request)
        {
            var response = new CreateResponse<ApplicationForm> { Success = false };

            #region Check if ProgramDetail exist
            var programDetail = await ProgramDetailRepository.GetById(programDetailId);
            if (programDetail is null)
            {
                response.ErrorReason = ErrorConstants.PROGRAM_DETAIL_DOSE_NOT_EXISTS;
                return response;
            }
            #endregion

            #region Check if the form Question fields
            var checkQuestionType = CheckIfAppFromQuestionIsValid(request.ApplicationFormAdditionalQuestion);
            if (!checkQuestionType.Success)
            {
                return checkQuestionType;
            }
            checkQuestionType = CheckIfAppFromQuestionIsValid(request.PersonalInformation.ApplicationFormQuestion);
            if (!checkQuestionType.Success)
            {
                return checkQuestionType;
            }
            #endregion

            #region save application to db
            // Update properties of the existing ApplicationForm with values from the request.
            var applicationForm = Mapper.Map<ApplicationForm>(request);

            // Update the LastModifiedDate 
            programDetail.LastModifiedDate = DateTime.UtcNow;

            // Save the changes to the ApplicationForm.
            programDetail.ApplicationForm = applicationForm;
            var updatedForm = await ProgramDetailRepository.Update(programDetail);
            if (updatedForm == null)
            {
                response.ErrorReason = ErrorConstants.UPDATE_APPLICATION_FORM_FAILED;
                return response;
            }
            #endregion

            response.Data = programDetail.ApplicationForm;
            response.Success = true;
            return response;
        }

    }

}
