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
    public class UserRepository : IUserRepository
    {
        private readonly SurveyDbContext _surveyDbContext;

        public UserRepository(SurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }

        public async Task CreateAsync(User entity)
        {
            await _surveyDbContext.Users.AddAsync(entity);
            await _surveyDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var deleting = await _surveyDbContext.Users.FindAsync(id);
            _surveyDbContext.Users.Remove(deleting);
            await _surveyDbContext.SaveChangesAsync();
        }

        public IList<User?> GetAll()
        {
            return _surveyDbContext.Users.ToList();
        }

        public async Task<IList<User?>> GetAllAsync()
        {
            return await _surveyDbContext.Users.ToListAsync();
        }

        public async Task<User?> GetAsync(int id)
        {
            return await _surveyDbContext.Users.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _surveyDbContext.Users.AnyAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(User entity)
        {
            _surveyDbContext.Users.Update(entity);
            await _surveyDbContext.SaveChangesAsync();
        }
    }
}
