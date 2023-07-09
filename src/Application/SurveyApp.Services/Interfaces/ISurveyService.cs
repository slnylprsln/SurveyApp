using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services.Interfaces
{
    public interface ISurveyService
    {
        Task CreateAsync(CreateNewSurveyRequest createRequest);
        Task<int> CreateAndReturnIdAsync(CreateNewSurveyRequest createRequest);
        SurveyDisplayResponse Get(int id);
        Task<UpdateSurveyRequest> GetForUpdate(int id);
        Task DeleteAsync(int id);
        IEnumerable<SurveyDisplayResponse> GetDisplayResponses();
        IEnumerable<SurveyDisplayResponse> GetSurveysByUser(int id);
        Task Update(UpdateSurveyRequest updateRequest);
        Task<bool> IsExists(int id);
    }
}
