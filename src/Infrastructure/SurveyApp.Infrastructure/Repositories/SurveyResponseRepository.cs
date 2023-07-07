using Microsoft.EntityFrameworkCore;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Data;
using SurveyApp.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Infrastructure.Repositories
{
    public class SurveyResponseRepository : ISurveyResponseRepository
    {
        private readonly SurveyDbContext _surveyDbContext;

        public SurveyResponseRepository(SurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }

        public async Task CreateAsync(SurveyResponse entity)
        {
            await _surveyDbContext.SurveyResponses.AddAsync(entity);
            await _surveyDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deleting = await _surveyDbContext.SurveyResponses.FindAsync(id);
            _surveyDbContext.SurveyResponses.Remove(deleting);
            await _surveyDbContext.SaveChangesAsync();
        }

        public async Task<IList<SurveyResponse?>> GetAllAsync()
        {
            return await _surveyDbContext.SurveyResponses.ToListAsync();
        }

        public IList<SurveyResponse?> GetAll()
        {
            return _surveyDbContext.SurveyResponses.ToList();
        }

        public async Task<SurveyResponse?> GetAsync(int id)
        {
            return await _surveyDbContext.SurveyResponses.FirstOrDefaultAsync(c => c.Id == id);
        }

        public IEnumerable<SurveyResponse> GetSurveyResponsesByQuestion(int questionId)
        {
            return _surveyDbContext.SurveyResponses.AsNoTracking().Where(c => c.QuestionId == questionId).ToList();
        }

        public IEnumerable<SurveyResponse> GetSurveyResponsesBySurvey(int surveyId)
        {
            return _surveyDbContext.SurveyResponses.AsNoTracking().Where(c => c.SurveyId == surveyId).ToList();
        }

        public IEnumerable<SurveyResponse> GetSurveyResponsesForAQuestionOfSurvey(int surveyId, int questionId)
        {
            return _surveyDbContext.SurveyResponses.AsNoTracking().Where(c => (c.SurveyId == surveyId && c.QuestionId == questionId)).ToList();
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _surveyDbContext.SurveyResponses.AnyAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(SurveyResponse entity)
        {
            _surveyDbContext.SurveyResponses.Update(entity);
            await _surveyDbContext.SaveChangesAsync();
        }
    }
}
