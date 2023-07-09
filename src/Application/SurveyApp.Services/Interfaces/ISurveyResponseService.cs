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
    public interface ISurveyResponseService
    {
        Task CreateAsync(CreateNewSurveyResponseRequest createRequest);
        Task<int> CreateAndReturnIdAsync(CreateNewSurveyResponseRequest createRequest);
        SurveyResponseDisplayResponse Get(int id);
        Task DeleteAsync(int id);
        IEnumerable<SurveyResponseDisplayResponse> GetDisplayResponses();
        Task<bool> IsExists(int id);
        IEnumerable<SurveyResponseDisplayResponse> GetSurveyResponsesBySurvey(int surveyId);
        IEnumerable<SurveyResponseDisplayResponse> GetSurveyResponsesByQuestion(int questionId);
        IEnumerable<SurveyResponseDisplayResponse> GetSurveyResponsesForAQuestionOfSurvey(int surveyId, int questionId);
    }
}
