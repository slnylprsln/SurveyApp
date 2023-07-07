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
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _repository;
        private readonly IMapper _mapper;

        public SurveyService(ISurveyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> CreateAndReturnIdAsync(CreateNewSurveyRequest createRequest)
        {
            var mapped = _mapper.Map<Survey>(createRequest);
            await _repository.CreateAsync(mapped);
            return mapped.Id;
        }

        public async Task CreateAsync(CreateNewSurveyRequest createRequest)
        {
            var mapped = _mapper.Map<Survey>(createRequest);
            await _repository.CreateAsync(mapped);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public SurveyDisplayResponse GetAsync(int id)
        {
            var found = _repository.GetAsync(id);
            return _mapper.Map<SurveyDisplayResponse>(found);
        }

        public IEnumerable<SurveyDisplayResponse> GetDisplayResponses()
        {
            var list = _repository.GetAll();
            var responses = list.ConvertSurveyToDisplayResponses(_mapper);
            return responses;
        }

        public async Task<UpdateSurveyRequest> GetForUpdate(int id)
        {
            var found = await _repository.GetAsync(id);
            return _mapper.Map<UpdateSurveyRequest>(found);
        }

        public IEnumerable<SurveyDisplayResponse> GetSurveysByUser(int id)
        {
            var list = _repository.GetSurveysByUser(id);
            var responses = list.ConvertSurveyToDisplayResponses(_mapper);
            return responses;
        }

        public async Task<bool> IsExists(int id)
        {
            return await _repository.IsExistsAsync(id);
        }

        public async Task Update(UpdateSurveyRequest updateRequest)
        {
            var mapped = _mapper.Map<Survey>(updateRequest);
            await _repository.UpdateAsync(mapped);
        }
    }
}
