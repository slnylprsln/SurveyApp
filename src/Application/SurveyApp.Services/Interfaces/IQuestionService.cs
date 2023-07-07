using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services.Interfaces
{
    public interface IQuestionService
    {
        Task CreateAsync(CreateNewQuestionRequest createRequest);
        Task<int> CreateAndReturnIdAsync(CreateNewQuestionRequest createRequest);
        QuestionDisplayResponse GetAsync(int id);
        Task<UpdateQuestionRequest> GetForUpdate(int id);
        Task DeleteAsync(int id);
        IEnumerable<QuestionDisplayResponse> GetDisplayResponses();
        IEnumerable<QuestionDisplayResponse> GetQuestionsBySurvey(int id);
        Task<IEnumerable<string>> GetOptionsOfQuestion(int id);
        Task Update(UpdateQuestionRequest updateRequest);
        Task<bool> IsExists(int id);
    }
}
