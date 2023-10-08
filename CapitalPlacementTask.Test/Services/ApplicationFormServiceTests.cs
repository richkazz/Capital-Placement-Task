

using AutoMapper;
using CapitalPlacementTask.DTOs;
using CapitalPlacementTask.Enums;
using CapitalPlacementTask.IRepositories;
using CapitalPlacementTask.Models;
using CapitalPlacementTask.Services;
using Moq;

namespace CapitalPlacementTask.Tests
{
    public class ApplicationFormServiceTests
    {
        private Mock<IProgramDetailRepository> programDetailRepositoryMock = new Mock<IProgramDetailRepository>();
        private Mock<IMapper> mapperMock = new Mock<IMapper>();
        [Test]
        public async Task GetByProgramDetailId_ReturnsApplicationForm()
        {
            // Arrange
            Guid programDetailId = Guid.NewGuid();
            var programDetail = new ProgramDetail
            {
                ProgramTitle = "karo",
                ProgramDescription = "karo",
                ProgramLocation = "karo",
                Id = programDetailId,
                ApplicationForm = new ApplicationForm
                {
                    CoverImageUrl = "ImageURL",
                    PersonalInformation = new ApplicationFormPersonalInformation
                    {
                        Email = "",
                        FirstName = "",
                        LastName = ""
                    }
                }
            };

            programDetailRepositoryMock.Setup(repo => repo.GetById(programDetailId))
                .ReturnsAsync(programDetail);


            var applicationFormService = new ApplicationFormService(programDetailRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = await applicationFormService.GetByProgramDetailId(programDetailId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(programDetail.ApplicationForm.CoverImageUrl, result.CoverImageUrl);
        }

        [Test]
        public async Task Update_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            Guid programDetailId = Guid.NewGuid();
            var programDetail = new ProgramDetail
            {
                ProgramTitle = "karo",
                ProgramDescription = "karo",
                ProgramLocation = "karo",
                Id = programDetailId,
                ApplicationForm = new ApplicationForm
                {
                    CoverImageUrl = "ImageURL",
                    PersonalInformation = new ApplicationFormPersonalInformation
                    {
                        Email = "",
                        FirstName = "",
                        LastName = ""
                    }
                }
            };
            var request = new ApplicationFormDTO
            {
                CoverImageUrl = "NewImageURL",
                PersonalInformation = new ApplicationFormPersonalInformationDTO
                {
                    Email = "",
                    FirstName = "",
                    LastName = "",
                    ApplicationFormQuestion = new List<ApplicationFormQuestion>
                    {
                        new ApplicationFormQuestion
                        {
                            Type = QuestionType.Paragraph
                        }
                    }
                },
                ApplicationFormAdditionalQuestion = new List<ApplicationFormQuestion>
                {
                    new ApplicationFormQuestion
                    {
                        Type = QuestionType.Paragraph
                    }
                }
            };

            programDetailRepositoryMock.Setup(repo => repo.GetById(programDetailId))
                .ReturnsAsync(programDetail);
            programDetailRepositoryMock.Setup(repo => repo.Update(It.IsAny<ProgramDetail>()))
                .ReturnsAsync(programDetail); // Return the same object for simplicity

            mapperMock.Setup(mapper => mapper.Map<ApplicationForm>(request))
                .Returns(new ApplicationForm()
                {
                    CoverImageUrl = "NewImageURL",

                    PersonalInformation = new ApplicationFormPersonalInformation
                    {
                        Email = "",
                        FirstName = "",
                        LastName = "",
                        ApplicationFormQuestion = new List<ApplicationFormQuestion>
                    {
                        new ApplicationFormQuestion
                        {
                            Type = QuestionType.Paragraph
                        }
                    }
                    },
                });

            var applicationFormService = new ApplicationFormService(programDetailRepositoryMock.Object, mapperMock.Object);

            // Act
            var result = await applicationFormService.Update(programDetailId, request);

            // Assert
            Assert.True(result.Success);
            Assert.AreEqual("NewImageURL", result.Data.CoverImageUrl);
        }
        [Test]
        public async Task Update_WhenProgramDetailNotFound_ReturnsError()
        {
            // Arrange
            Guid programDetailId = Guid.NewGuid(); // Generate a new, non-existent ID.

            programDetailRepositoryMock.Setup(repo => repo.GetById(It.IsAny<Guid>()))
                .ReturnsAsync((ProgramDetail)null); // Simulate that ProgramDetail doesn't exist.

            var applicationFormService = new ApplicationFormService(programDetailRepositoryMock.Object, mapperMock.Object);

            var request = new ApplicationFormDTO
            {
                CoverImageUrl = "NewImageURL",
                PersonalInformation = new ApplicationFormPersonalInformationDTO
                {
                    Email = "",
                    FirstName = "",
                    LastName = "",
                    ApplicationFormQuestion = new List<ApplicationFormQuestion>
                    {
                        new ApplicationFormQuestion
                        {
                            Type = QuestionType.Paragraph
                        }
                    }
                },
                ApplicationFormAdditionalQuestion = new List<ApplicationFormQuestion>
                {
                    new ApplicationFormQuestion
                    {
                        Type = QuestionType.Paragraph
                    }
                }
            };

            // Act
            var result = await applicationFormService.Update(programDetailId, request);

            // Assert
            Assert.False(result.Success);
            Assert.AreEqual("ProgramDetail does not exist.", result.ErrorReason);
            Assert.Null(result.Data);
        }

        [Test]
        public async Task Update_WithInvalidQuestionType_ReturnsError()
        {
            // Arrange
            Guid programDetailId = Guid.NewGuid(); // Generate a valid ID.
            var programDetailRepositoryMock = new Mock<IProgramDetailRepository>();
            programDetailRepositoryMock.Setup(repo => repo.GetById(programDetailId))
                .ReturnsAsync(new ProgramDetail
                {
                    ProgramTitle = "karo",
                    ProgramDescription = "karo",
                    ProgramLocation = "karo",
                    Id = programDetailId,
                    ApplicationForm = new ApplicationForm
                    {
                        CoverImageUrl = "ImageURL",
                        PersonalInformation = new ApplicationFormPersonalInformation
                        {
                            Email = "",
                            FirstName = "",
                            LastName = ""
                        }
                    }
                }); // Simulate that ProgramDetail exists.

            var mapperMock = new Mock<IMapper>();
            var applicationFormService = new ApplicationFormService(programDetailRepositoryMock.Object, mapperMock.Object);

            var request = new ApplicationFormDTO
            {
                CoverImageUrl = "NewImageURL",
                PersonalInformation = new ApplicationFormPersonalInformationDTO
                {
                    Email = "",
                    FirstName = "",
                    LastName = "",
                    ApplicationFormQuestion = new List<ApplicationFormQuestion>
                    {
                        new ApplicationFormQuestion
                        {
                            Type = QuestionType.Paragraph
                        }
                    }
                },
                ApplicationFormAdditionalQuestion = new List<ApplicationFormQuestion>
                {
                    new ApplicationFormQuestion
                    {
                        Type = QuestionType.Paragraph
                    }
                }
            };

            // Act
            var result = await applicationFormService.Update(programDetailId, request);

            // Assert
            Assert.False(result.Success);
            Assert.Null(result.Data);
        }

    }
}
