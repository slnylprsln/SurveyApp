using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Infrastructure.Repositories.Interfaces
{
    public interface ISurveyResponseRepository : IRepository<SurveyResponse>
    {
        IEnumerable<SurveyResponse> GetSurveyResponsesBySurvey(int surveyId);
        IEnumerable<SurveyResponse> GetSurveyResponsesByQuestion(int questionId);
        IEnumerable<SurveyResponse> GetSurveyResponsesForAQuestionOfSurvey(int surveyId, int questionId);
    }
}
