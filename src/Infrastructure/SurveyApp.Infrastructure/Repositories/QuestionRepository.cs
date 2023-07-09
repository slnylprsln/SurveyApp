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
    public class QuestionRepository : IQuestionRepository
    {
        private readonly SurveyDbContext _surveyDbContext;

        public QuestionRepository(SurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }

        public async Task CreateAsync(Question entity)
        {
            await _surveyDbContext.Questions.AddAsync(entity);
            await _surveyDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deleting = await _surveyDbContext.Questions.FindAsync(id);
            _surveyDbContext.Questions.Remove(deleting);
            await _surveyDbContext.SaveChangesAsync();
        }

        public async Task<IList<Question>> GetAllAsync()
        {
            return await _surveyDbContext.Questions.ToListAsync();
        }

        public IList<Question> GetAll()
        {
            return _surveyDbContext.Questions.ToList();
        }

        public Question Get(int id)
        {
            return _surveyDbContext.Questions.FirstOrDefault(c => c.Id == id);
        }

        public async Task<Question> GetAsync(int id)
        {
            return await _surveyDbContext.Questions.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Question>> GetQuestionsBySurveyAsync(int surveyId)
        {
            return await _surveyDbContext.Questions.AsNoTracking().Where(c => c.SurveyId == surveyId).ToListAsync();
        }

        public IEnumerable<Question> GetQuestionsBySurvey(int surveyId)
        {
            return _surveyDbContext.Questions.AsNoTracking().Where(c => c.SurveyId == surveyId).ToList();
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _surveyDbContext.Questions.AnyAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Question entity)
        {
            _surveyDbContext.Questions.Update(entity);
            await _surveyDbContext.SaveChangesAsync();
        }
    }
}
