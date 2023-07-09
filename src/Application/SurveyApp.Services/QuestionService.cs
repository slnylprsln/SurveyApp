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
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> CreateAndReturnIdAsync(CreateNewQuestionRequest createRequest)
        {
            var mapped = _mapper.Map<Question>(createRequest);
            await _repository.CreateAsync(mapped);
            return mapped.Id;
        }

        public async Task CreateAsync(CreateNewQuestionRequest createRequest)
        {
            var mapped = _mapper.Map<Question>(createRequest);
            await _repository.CreateAsync(mapped);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public QuestionDisplayResponse Get(int id)
        {
            var found = _repository.Get(id);
            return _mapper.Map<QuestionDisplayResponse>(found);
        }

        public IEnumerable<QuestionDisplayResponse> GetDisplayResponses()
        {
            var list = _repository.GetAll();
            var responses = list.ConvertQuestionToDisplayResponses(_mapper);
            return responses;
        }

        public async Task<UpdateQuestionRequest> GetForUpdate(int id)
        {
            var found = await _repository.GetAsync(id);
            return _mapper.Map<UpdateQuestionRequest>(found);
        }

        public IEnumerable<string> GetOptionsOfQuestion(int id)
        {
            var found = _repository.Get(id);
            return found.GetOptions();
        }

        public IEnumerable<QuestionDisplayResponse> GetQuestionsBySurvey(int id)
        {
            var list = _repository.GetQuestionsBySurvey(id);
            var responses = list.ConvertQuestionToDisplayResponses(_mapper);
            return responses;
        }

        public async Task<bool> IsExists(int id)
        {
            return await _repository.IsExistsAsync(id);
        }

        public async Task Update(UpdateQuestionRequest updateRequest)
        {
            var mapped = _mapper.Map<Question>(updateRequest);
            await _repository.UpdateAsync(mapped);
        }
    }
}
