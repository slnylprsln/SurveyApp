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
            CreateMap<CreateNewQuestionRequest, Question>().ReverseMap();
            CreateMap<CreateNewSurveyRequest, Survey>().ReverseMap();
            CreateMap<CreateNewUserRequest, User>().ReverseMap();
            CreateMap<CreateNewSurveyResponseRequest, SurveyResponse>().ReverseMap();

            CreateMap<UpdateQuestionRequest, Question>().ReverseMap();
            CreateMap<UpdateSurveyRequest, Survey>().ReverseMap();
            CreateMap<UpdateUserRequest, User>().ReverseMap();

            CreateMap<Question, QuestionDisplayResponse>().ReverseMap();
            CreateMap<Survey, SurveyDisplayResponse>().ReverseMap();
            CreateMap<User, UserDisplayResponse>().ReverseMap();
            CreateMap<SurveyResponse, SurveyResponseDisplayResponse>().ReverseMap();
        }
    }
}
