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
    public interface IUserService
    {
        Task CreateAsync(CreateNewUserRequest createRequest);
        Task<int> CreateAndReturnIdAsync(CreateNewUserRequest createRequest);
        UserDisplayResponse GetAsync(int id);
        Task<UpdateUserRequest> GetForUpdate(int id);
        Task DeleteAsync(int id);
        IEnumerable<UserDisplayResponse> GetDisplayResponses();
        Task Update(UpdateUserRequest updateRequest);
        Task<bool> IsExists(int id);
    }
}
