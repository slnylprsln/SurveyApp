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
    public class SurveyResponseService : ISurveyResponseService
    {
        private readonly ISurveyResponseRepository _repository;
        private readonly IMapper _mapper;

        public SurveyResponseService(ISurveyResponseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> CreateAndReturnIdAsync(CreateNewSurveyResponseRequest createRequest)
        {
            var mapped = _mapper.Map<SurveyResponse>(createRequest);
            await _repository.CreateAsync(mapped);
            return mapped.Id;
        }

        public async Task CreateAsync(CreateNewSurveyResponseRequest createRequest)
        {
            var mapped = _mapper.Map<SurveyResponse>(createRequest);
            await _repository.CreateAsync(mapped);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public SurveyResponseDisplayResponse Get(int id)
        {
            var found = _repository.Get(id);
            return _mapper.Map<SurveyResponseDisplayResponse>(found);
        }

        public IEnumerable<SurveyResponseDisplayResponse> GetDisplayResponses()
        {
            var list = _repository.GetAll();
            var responses = list.ConvertSurveyResponseToDisplayResponses(_mapper);
            return responses;
        }

        public IEnumerable<SurveyResponseDisplayResponse> GetSurveyResponsesByQuestion(int questionId)
        {
            var list = _repository.GetSurveyResponsesByQuestion(questionId);
            var responses = list.ConvertSurveyResponseToDisplayResponses(_mapper);
            return responses;
        }

        public IEnumerable<SurveyResponseDisplayResponse> GetSurveyResponsesBySurvey(int surveyId)
        {
            var list = _repository.GetSurveyResponsesBySurvey(surveyId);
            var responses = list.ConvertSurveyResponseToDisplayResponses(_mapper);
            return responses;
        }

        public IEnumerable<SurveyResponseDisplayResponse> GetSurveyResponsesForAQuestionOfSurvey(int surveyId, int questionId)
        {
            var list = _repository.GetSurveyResponsesForAQuestionOfSurvey(surveyId, questionId);
            var responses = list.ConvertSurveyResponseToDisplayResponses(_mapper);
            return responses;
        }

        public async Task<bool> IsExists(int id)
        {
            return await _repository.IsExistsAsync(id);
        }
    }
}
