using Microsoft.EntityFrameworkCore.ChangeTracking;
using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task<T?> GetAsync(int id);
        IList<T?> GetAll();
        Task<IList<T?>> GetAllAsync();
        Task CreateAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
        Task<bool> IsExistsAsync(int id);
    }
}
