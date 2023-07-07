using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Infrastructure.Repositories.Interfaces
{
    public interface ISurveyRepository : IRepository<Survey>
    {
        Task<IEnumerable<Survey>> GetSurveysByUserAsync(int id);
        IEnumerable<Survey> GetSurveysByUser(int id);
    }
}
