## CapitalPlacementTask API Documentation

### Overview
The CapitalPlacementTask API provides endpoints for managing program details, application forms, program workflows, and related functionalities.

### Base URL
The base URL for accessing the API is `https://api.example.com`.

### Authentication
Authentication is required for some endpoints. Refer to the specific endpoint documentation for authentication details.

### Error Handling
The API returns standard HTTP status codes to indicate the success or failure of requests. In case of an error, additional error details may be included in the response body.

---

### ProgramDetailController

#### Get All Program Details
- **Endpoint:** `GET /api/ProgramDetail`
- **Description:** Get a list of all program details.
- **Response Format:** JSON
- **Response Status Codes:**
  - 200 OK: Successful request.
- **Example Request:**
  ```http
  GET https://api.example.com/api/ProgramDetail
  ```
- **Example Response:**
  ```json
  [
    {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "createdDate": "2023-10-07T23:11:33.621Z",
    "lastModifiedDate": "2023-10-07T23:11:33.621Z",
    "isDeleted": true,
    "programTitle": "string",
    "programSummary": "string",
    "programDescription": "string",
    "skillsNeeded": [
      "string"
    ],
    "programBenefits": "string",
    "applicationCriteria": "string",
    "programType": 1,
    "programStart": "2023-10-07T23:11:33.621Z",
    "applicationOpen": "2023-10-07T23:11:33.621Z",
    "applicationClose": "2023-10-07T23:11:33.621Z",
    "duration": "string",
    "programLocation": "string",
    "isRemote": true,
    "minimumQualification": 0,
    "maximumApplication": 0,
    "applicationForm": {
      "coverImageUrl": "string",
      "personalInformation": {
        "firstName": "string",
        "lastName": "string",
        "email": "string",
        "applicationFormQuestion": [
          {
            "type": 1,
            "questionText": "string",
            "isVisible": true,
            "isInternal": true,
            "applicationFormQuestionMultipleChoice": {
              "maxChoices": 0,
              "choices": [
                {
                  "optionText": "string"
                }
              ]
            },
            "applicationFormQuestionDropDown": {
              "options": [
                {
                  "optionText": "string"
                }
              ]
            },
            "applicationFormQuestionYesOrNo": {
              "disqualifyCandidate": true
            }
          }
        ]
      },
      "applicationFormProfile": [
        {
          "questionText": "string",
          "isMandatory": true,
          "isInternal": true
        }
      ],
      "applicationFormAdditionalQuestion": [
        {
          "type": 1,
          "questionText": "string",
          "isVisible": true,
          "isInternal": true,
          "applicationFormQuestionMultipleChoice": {
            "maxChoices": 0,
            "choices": [
              {
                "optionText": "string"
              }
            ]
          },
          "applicationFormQuestionDropDown": {
            "options": [
              {
                "optionText": "string"
              }
            ]
          },
          "applicationFormQuestionYesOrNo": {
            "disqualifyCandidate": true
          }
        }
      ]
    },
    "stages": [
      {
        "stageName": "string",
        "stageType": 1,
        "videoInterviewQuestions": [
          {
            "questionText": "string",
            "additionalInformation": "string",
            "maxVideoDuration": {
              "ticks": 0,
              "days": 0,
              "hours": 0,
              "milliseconds": 0,
              "microseconds": 0,
              "nanoseconds": 0,
              "minutes": 0,
              "seconds": 0,
              "totalDays": 0,
              "totalHours": 0,
              "totalMilliseconds": 0,
              "totalMicroseconds": 0,
              "totalNanoseconds": 0,
              "totalMinutes": 0,
              "totalSeconds": 0
            },
            "videoSubmissionDeadline": {
              "ticks": 0,
              "days": 0,
              "hours": 0,
              "milliseconds": 0,
              "microseconds": 0,
              "nanoseconds": 0,
              "minutes": 0,
              "seconds": 0,
              "totalDays": 0,
              "totalHours": 0,
              "totalMilliseconds": 0,
              "totalMicroseconds": 0,
              "totalNanoseconds": 0,
              "totalMinutes": 0,
              "totalSeconds": 0
            }
          }
        ],
        "isVisibleToCandidate": true
      }
    ]
  },
    ...
  ]
  ```

#### Get Program Detail by ID
- **Endpoint:** `GET /api/ProgramDetail/{id}`
- **Description:** Get program details by ID.
- **Response Format:** JSON
- **Response Status Codes:**
  - 200 OK: Successful request.
  - 404 Not Found: Program detail not found.
- **Example Request:**
  ```http
  GET https://api.example.com/api/ProgramDetail/123456
  ```
- **Example Response:**
  ```json
  {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "createdDate": "2023-10-07T23:11:33.621Z",
    "lastModifiedDate": "2023-10-07T23:11:33.621Z",
    "isDeleted": true,
    "programTitle": "string",
    "programSummary": "string",
    "programDescription": "string",
    "skillsNeeded": [
      "string"
    ],
    "programBenefits": "string",
    "applicationCriteria": "string",
    "programType": 1,
    "programStart": "2023-10-07T23:11:33.621Z",
    "applicationOpen": "2023-10-07T23:11:33.621Z",
    "applicationClose": "2023-10-07T23:11:33.621Z",
    "duration": "string",
    "programLocation": "string",
    "isRemote": true,
    "minimumQualification": 0,
    "maximumApplication": 0,
    "applicationForm": {
      "coverImageUrl": "string",
      "personalInformation": {
        "firstName": "string",
        "lastName": "string",
        "email": "string",
        "applicationFormQuestion": [
          {
            "type": 1,
            "questionText": "string",
            "isVisible": true,
            "isInternal": true,
            "applicationFormQuestionMultipleChoice": {
              "maxChoices": 0,
              "choices": [
                {
                  "optionText": "string"
                }
              ]
            },
            "applicationFormQuestionDropDown": {
              "options": [
                {
                  "optionText": "string"
                }
              ]
            },
            "applicationFormQuestionYesOrNo": {
              "disqualifyCandidate": true
            }
          }
        ]
      },
      "applicationFormProfile": [
        {
          "questionText": "string",
          "isMandatory": true,
          "isInternal": true
        }
      ],
      "applicationFormAdditionalQuestion": [
        {
          "type": 1,
          "questionText": "string",
          "isVisible": true,
          "isInternal": true,
          "applicationFormQuestionMultipleChoice": {
            "maxChoices": 0,
            "choices": [
              {
                "optionText": "string"
              }
            ]
          },
          "applicationFormQuestionDropDown": {
            "options": [
              {
                "optionText": "string"
              }
            ]
          },
          "applicationFormQuestionYesOrNo": {
            "disqualifyCandidate": true
          }
        }
      ]
    },
    "stages": [
      {
        "stageName": "string",
        "stageType": 1,
        "videoInterviewQuestions": [
          {
            "questionText": "string",
            "additionalInformation": "string",
            "maxVideoDuration": {
              "ticks": 0,
              "days": 0,
              "hours": 0,
              "milliseconds": 0,
              "microseconds": 0,
              "nanoseconds": 0,
              "minutes": 0,
              "seconds": 0,
              "totalDays": 0,
              "totalHours": 0,
              "totalMilliseconds": 0,
              "totalMicroseconds": 0,
              "totalNanoseconds": 0,
              "totalMinutes": 0,
              "totalSeconds": 0
            },
            "videoSubmissionDeadline": {
              "ticks": 0,
              "days": 0,
              "hours": 0,
              "milliseconds": 0,
              "microseconds": 0,
              "nanoseconds": 0,
              "minutes": 0,
              "seconds": 0,
              "totalDays": 0,
              "totalHours": 0,
              "totalMilliseconds": 0,
              "totalMicroseconds": 0,
              "totalNanoseconds": 0,
              "totalMinutes": 0,
              "totalSeconds": 0
            }
          }
        ],
        "isVisibleToCandidate": true
      }
    ]
  }
  ```

#### Create Program Detail
- **Endpoint:** `POST /api/ProgramDetail`
- **Description:** Create a new program detail.
- **Request Format:** JSON
- **Response Format:** JSON
- **Response Status Codes:**
  - 200 OK: Successful request.
  - 400 Bad Request: Invalid request data.
- **Example Request:**
  ```http
  POST https://api.example.com/api/ProgramDetail
  Content-Type: application/json

  {
    "ProgramTitle": "New Program",
    ...
  }
  ```
- **Example Response:**
  ```json
  {
    "Id": "789012",
    "ProgramTitle": "New Program",
    ...
  }
  ```

#### Update Program Detail
- **Endpoint:** `PUT /api/ProgramDetail/{id}`
- **Description:** Update program details by ID.
- **Request Format:** JSON
- **Response Format:** JSON
- **Response Status Codes:**
  - 200 OK: Successful request.
  - 404 Not Found: Program detail not found.
  - 400 Bad Request: Invalid request data.
- **Example Request:**
  ```http
  PUT https://api.example.com/api/ProgramDetail/789012
  Content-Type: application/json

  {
    "ProgramTitle": "Updated Program",
    ...
  }
  ```
- **Example Response:**
  ```json
  {
    "Id": "789012",
    "ProgramTitle": "Updated Program",
    ...
  }
  ```
[Api Swagger View](https://github.com/richkazz/Capital-Placement-Task/assets/58124029/064e26a4-33d9-4707-8247-be1cae534765)

---

### ApplicationFormController

#### Get Application Form by Program Detail ID
- **Endpoint:** `GET /api/ApplicationForm/{programDetailId}`
- **Description:** Get the application form by program detail ID.
- **Response Format:** JSON
- **Response Status Codes:**
  - 200 OK: Successful request.
  - 404 Not Found: Application form not found.
- **Example Request:**
  ```http
  GET https://api.example.com/api/ApplicationForm/123456
  ```
- **Example Response:**
  ```json
  {
    "CoverImageUrl": "https://example.com/image.jpg",
    ...
  }
  ```

#### Update Application Form
- **Endpoint:** `PUT /api/ApplicationForm/{programDetailId}`
- **Description:** Update the application form for a program.
- **Request Format:** JSON
- **Response Format:** JSON
- **Response Status Codes:**
  - 200 OK: Successful request.
  - 404 Not Found: Program detail not found.
  - 400 Bad Request: Invalid request data.
- **Example Request:**
  ```http
  PUT https://api.example.com/api/ApplicationForm/123456
  Content-Type: application/json

  {
    "CoverImageUrl": "https://example.com/updated-image.jpg",
    ...
  }
  ```
- **Example Response:**
  ```json
  {
    "CoverImageUrl": "https://example.com/updated-image.jpg",
    ...
  }
  ```

---

### WorkFlowController

#### Get Workflow Stages by Program Detail ID
- **Endpoint:** `GET /api/WorkFlow/{programDetailId}`
- **Description:** Get workflow stages by program detail ID.
- **Response Format:** JSON
- **Response Status Codes:**
  - 200 OK: Successful request.
  - 404 Not Found: Workflow stages not found.
- **Example Request:**
  ```http
  GET https://api.example.com/api/WorkFlow/123456
  ```
- **Example Response:**
  ```json
  [
    {
      "StageName": "Stage 1",
      ...
    },
    ...
  ]
  ```

#### Update Workflow Stages
- **Endpoint:** `PUT /api/WorkFlow/{programDetailId}`
- **Description:** Update workflow stages for a program.
- **Request Format:** JSON
- **Response Format:** JSON
- **Response Status Codes:**
  - 200 OK: Successful request.
  - 404 Not Found: Program detail not found.
  - 400 Bad Request: Invalid request data.
- **Example Request:**
  ```http
  PUT https://api.example.com/api/WorkFlow/123456
  Content-Type: application/json

  [
    {
      "StageName": "Updated Stage 1",
      ...
    },
    ...
  ]
  ```
- **Example Response:**
  ```json
  [
    {
      "StageName": "Updated Stage 1",
      ...
    },
    ...
  ]
  ```

---

### PreviewController

#### Get Program Detail by ID (Preview)
- **Endpoint:** `GET /api/Preview/{programDetailId}`
- **Description:** Get program details by ID for preview purposes.
- **Response Format:** JSON
- **Response Status Codes:**
  - 200 OK: Successful request.
  - 404 Not Found: Program detail not found.
- **Example Request:**
  ```http
  GET https://api.example.com/api/Preview/123456
  ```
- **Example Response:**
  ```json
  {
    "Id": "123456",
    "ProgramTitle": "Sample Program",
    ...
  }
  ```

---
```markdown
#### Namespace (Continued)
```csharp
using CapitalPlacementTask.Services
```

#### Class Methods

##### Get Application Form by Program Detail ID
- **Method:** `GetByProgramDetailId(Guid programDetailId)`
- **Description:** Retrieves the application form associated with the specified program detail ID.
- **Parameters:**
  - `programDetailId` (Type: `Guid`): The ID of the program detail for which to retrieve the application form.
- **Return Type:** `ApplicationForm`
- **Example Usage:**
  ```csharp
  var applicationForm = await ApplicationFormService.GetByProgramDetailId(programDetailId);
  ```

##### Update Application Form
- **Method:** `Update(Guid programDetailId, ApplicationFormDTO request)`
- **Description:** Updates the application form for a program detail with the specified ID using the provided data in the request.
- **Parameters:**
  - `programDetailId` (Type: `Guid`): The ID of the program detail to update.
  - `request` (Type: `ApplicationFormDTO`): The data to update the application form.
- **Return Type:** `CreateResponse<ApplicationForm>`
- **Example Usage:**
  ```csharp
  var response = await ApplicationFormService.Update(programDetailId, applicationFormDTO);
  ```

##### Check If Application Form Questions Are Valid
- **Method:** `CheckIfAppFromQuestionIsValid(List<ApplicationFormQuestion> applicationFormQuestions)`
- **Description:** Checks if the application form questions are valid and meet the required criteria.
- **Parameters:**
  - `applicationFormQuestions` (Type: `List<ApplicationFormQuestion>`): The list of application form questions to validate.
- **Return Type:** `CreateResponse<ApplicationForm>`
- **Example Usage:**
  ```csharp
  var response = CheckIfAppFromQuestionIsValid(applicationFormQuestions);
  ```

#### Class Constructors

##### ApplicationFormService Constructor
- **Constructor:** `ApplicationFormService(IProgramDetailRepository programDetailRepository, IMapper mapper)`
- **Description:** Initializes an instance of the `ApplicationFormService` class.
- **Parameters:**
  - `programDetailRepository` (Type: `IProgramDetailRepository`): The repository for program details.
  - `mapper` (Type: `IMapper`): The AutoMapper instance.
- **Example Usage:**
  ```csharp
  var applicationFormService = new ApplicationFormService(programDetailRepository, mapper);
  ```

---

### ProgramDetailService

#### Class Overview
The `ProgramDetailService` class provides services related to program details. It handles operations such as creating, retrieving, updating, and deleting program details.

#### Namespace
```csharp
using CapitalPlacementTask.Services;
```

#### Class Methods

##### Create Program Detail
- **Method:** `Create(ProgramDetailDTO request)`
- **Description:** Creates a new program detail using the provided data in the request.
- **Parameters:**
  - `request` (Type: `ProgramDetailDTO`): The data to create the program detail.
- **Return Type:** `CreateResponse<ProgramDetail>`
- **Example Usage:**
  ```csharp
  var response = await ProgramDetailService.Create(programDetailDTO);
  ```

##### Get All Program Details
- **Method:** `GetAll()`
- **Description:** Retrieves a list of all program details.
- **Return Type:** `List<ProgramDetail>`
- **Example Usage:**
  ```csharp
  var programDetails = await ProgramDetailService.GetAll();
  ```

##### Get Program Detail by ID
- **Method:** `GetById(Guid id)`
- **Description:** Retrieves program details by ID.
- **Parameters:**
  - `id` (Type: `Guid`): The ID of the program detail to retrieve.
- **Return Type:** `ProgramDetail`
- **Example Usage:**
  ```csharp
  var programDetail = await ProgramDetailService.GetById(id);
  ```

##### Update Program Detail
- **Method:** `Update(ProgramDetailDTO request, Guid id)`
- **Description:** Updates program details by ID using the provided data in the request.
- **Parameters:**
  - `request` (Type: `ProgramDetailDTO`): The data to update the program detail.
  - `id` (Type: `Guid`): The ID of the program detail to update.
- **Return Type:** `CreateResponse<ProgramDetail>`
- **Example Usage:**
  ```csharp
  var response = await ProgramDetailService.Update(programDetailDTO, id);
  ```

##### Check If Skills Needed Contains Duplicates
- **Method:** `HasDuplicates(List<string>? skillsNeeded)`
- **Description:** Checks if the list of skills needed contains duplicate values.
- **Parameters:**
  - `skillsNeeded` (Type: `List<string>?`): The list of skills needed to check for duplicates.
- **Return Type:** `bool`
- **Example Usage:**
  ```csharp
  var hasDuplicates = HasDuplicates(skillsNeeded);
  ```

#### Class Constructors

##### ProgramDetailService Constructor
- **Constructor:** `ProgramDetailService(IProgramDetailRepository programDetailRepository, IMapper mapper)`
- **Description:** Initializes an instance of the `ProgramDetailService` class.
- **Parameters:**
  - `programDetailRepository` (Type: `IProgramDetailRepository`): The repository for program details.
  - `mapper` (Type: `IMapper`): The AutoMapper instance.
- **Example Usage:**
  ```csharp
  var programDetailService = new ProgramDetailService(programDetailRepository, mapper);
  ```

### StageService

#### Class Overview
The `StageService` class provides services related to program workflow stages. It handles operations such as retrieving and updating stages for a program.

#### Namespace
```csharp
using CapitalPlacementTask.Services;
```

#### Class Methods

##### Get Workflow Stages by Program Detail ID
- **Method:** `GetByProgramDetailId(Guid programDetailId)`
- **Description:** Retrieves workflow stages by program detail ID.
- **Parameters:**
  - `programDetailId` (Type: `Guid`): The ID of the program detail for which to retrieve stages.
- **Return Type:** `List<Stage>`
- **Example Usage:**
  ```csharp
  var stages = await StageService.GetByProgramDetailId(programDetailId);
  ```

##### Update Workflow Stages
- **Method:** `Update(List<StageDTO> request, Guid programDetailId)`
- **Description:** Updates workflow stages for a program with the specified ID using the provided data in the request.
- **Parameters:**
  - `request` (Type: `List<StageDTO>`): The data to update workflow stages.
  - `programDetailId` (Type: `Guid`): The ID of the program detail for which to update stages.
- **Return Type:** `CreateResponse<List<StageDTO>>`
- **Example Usage:**
  ```csharp
  var response = await StageService.Update(request, programDetailId);
  ```

#### Class Constructors

##### StageService Constructor
- **Constructor:** `StageService(IProgramDetailRepository programDetailRepository, IMapper mapper)`
- **Description:** Initializes an instance of the `StageService` class.
- **Parameters:**
  - `programDetailRepository` (Type: `I

ProgramDetailRepository`): The repository for program details.
  - `mapper` (Type: `IMapper`): The AutoMapper instance.
- **Example Usage:**
  ```csharp
  var stageService = new StageService(programDetailRepository, mapper);
  ```

---
### Conclusion
This API documentation provides an overview of the available endpoints and the services provided by the CapitalPlacementTask project. It also includes usage examples to help developers understand how to interact with the API. For more detailed information about specific endpoints and request/response formats, please refer to the corresponding sections above.
