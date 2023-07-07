using AutoMapper;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SurveyApp.Services.Mappings
{
    public class MapProfile : Profile
    { 
        public MapProfile()
        {
            CreateMap<CreateNewQuestionRequest, Question>();
            CreateMap<CreateNewSurveyRequest, Survey>();
            CreateMap<CreateNewUserRequest, User>();
            CreateMap<CreateNewSurveyResponseRequest, SurveyResponse>();

            CreateMap<UpdateQuestionRequest, Question>().ReverseMap();
            CreateMap<UpdateSurveyRequest, Survey>().ReverseMap();
            CreateMap<UpdateUserRequest, User>().ReverseMap();

            CreateMap<Question, QuestionDisplayResponse>();
            CreateMap<Survey, SurveyDisplayResponse>();
            CreateMap<User, UserDisplayResponse>();
            CreateMap<SurveyResponse, SurveyResponseDisplayResponse>();
        }
    }
}
