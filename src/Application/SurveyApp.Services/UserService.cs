using AutoMapper;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repositories.Interfaces;
using SurveyApp.Services.Extensions;
using SurveyApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly UserCreateValidator _userCreateValidator;
        private readonly UserUpdateValidator _userUpdateValidator;

        public UserService(IUserRepository repository, IMapper mapper, UserCreateValidator userCreateValidator, UserUpdateValidator userUpdateValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _userCreateValidator = userCreateValidator;
            _userUpdateValidator = userUpdateValidator;
        }

        public async Task<int> CreateAndReturnIdAsync(CreateNewUserRequest createRequest)
        {
            var validationResult = _userCreateValidator.Validate(createRequest);
            if (validationResult.IsValid)
            {
                var mapped = _mapper.Map<User>(createRequest);
                await _repository.CreateAsync(mapped);
                return mapped.Id;
            }
            else return 0;
        }

        public async Task CreateAsync(CreateNewUserRequest createRequest)
        {
            var validationResult = _userCreateValidator.Validate(createRequest);
            if (validationResult.IsValid)
            {
                var mapped = _mapper.Map<User>(createRequest);
                await _repository.CreateAsync(mapped);
            }
            else
            {
                foreach (var error in validationResult.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public UserDisplayResponse Get(int id)
        {
            var found = _repository.Get(id);
            return _mapper.Map<UserDisplayResponse>(found);
        }

        public IEnumerable<UserDisplayResponse> GetDisplayResponses()
        {
            var list = _repository.GetAll();
            var responses = list.ConvertUserToDisplayResponses(_mapper);
            return responses;
        }

        public async Task<UpdateUserRequest> GetForUpdate(int id)
        {
            var found = await _repository.GetAsync(id);
            return _mapper.Map<UpdateUserRequest>(found);
        }

        public async Task<bool> IsExists(int id)
        {
            return await _repository.IsExistsAsync(id);
        }

        public async Task Update(UpdateUserRequest updateRequest)
        {
            var validationResult = _userUpdateValidator.Validate(updateRequest);
            if (validationResult.IsValid)
            {
                var mapped = _mapper.Map<User>(updateRequest);
                await _repository.UpdateAsync(mapped);
            }
            else
            {
                foreach (var error in validationResult.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
        }
    }
}
