using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Infrastructure.Repositories.Interfaces
{
    public interface IQuestionRepository : IRepository<Question>
    {
        public Task<IEnumerable<Question>> GetQuestionsBySurveyAsync(int surveyId);
        public IEnumerable<Question> GetQuestionsBySurvey(int surveyId);
        public IEnumerable<string> GetOptionsOfQuestion(int questionId);
    }
}
