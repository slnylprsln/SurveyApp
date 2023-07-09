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
    public class SurveyRepository : ISurveyRepository
    {
        private readonly SurveyDbContext _surveyDbContext;

        public SurveyRepository(SurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }

        public async Task CreateAsync(Survey entity)
        {
            await _surveyDbContext.Surveys.AddAsync(entity);
            await _surveyDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deleting = await _surveyDbContext.Surveys.FindAsync(id);
            _surveyDbContext.Surveys.Remove(deleting);
            await _surveyDbContext.SaveChangesAsync();
        }

        public async Task<IList<Survey>> GetAllAsync()
        {
            return await _surveyDbContext.Surveys.ToListAsync();
        }

        public IList<Survey> GetAll()
        {
            return _surveyDbContext.Surveys.ToList();
        }

        public Survey Get(int id)
        {
            return _surveyDbContext.Surveys.FirstOrDefault(c => c.Id == id);
        }

        public async Task<Survey> GetAsync(int id)
        {
            return await _surveyDbContext.Surveys.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Survey>> GetSurveysByUserAsync(int id)
        {
            return await _surveyDbContext.Surveys.AsNoTracking().Where(c => c.UserId == id).ToListAsync();
        }

        public IEnumerable<Survey> GetSurveysByUser(int id)
        {
            return _surveyDbContext.Surveys.AsNoTracking().Where(c => c.UserId == id).ToList();
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _surveyDbContext.Surveys.AnyAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Survey entity)
        {
            _surveyDbContext.Surveys.Update(entity);
            await _surveyDbContext.SaveChangesAsync();
        }
    }
}
