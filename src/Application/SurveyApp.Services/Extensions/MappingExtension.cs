using AutoMapper;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services.Extensions
{
    public static class MappingExtension
    {
        public static T ConvertQuestionToDto<T>(this IEnumerable<Question> questions, IMapper mapper)
        {
            return mapper.Map<T>(questions);
        }

        public static T ConvertSurveyToDto<T>(this IEnumerable<Survey> surveys, IMapper mapper)
        {
            return mapper.Map<T>(surveys);
        }

        public static T ConvertSurveyResponseToDto<T>(this IEnumerable<SurveyResponse> surveyResponses, IMapper mapper)
        {
            return mapper.Map<T>(surveyResponses);
        }

        public static T ConvertUserToDto<T>(this IEnumerable<User> users, IMapper mapper)
        {
            return mapper.Map<T>(users);
        }

        public static IEnumerable<QuestionDisplayResponse> ConvertQuestionToDisplayResponses(this IEnumerable<Question> questions, IMapper mapper)
        {
            return mapper.Map<IEnumerable<QuestionDisplayResponse>>(questions);
        }

        public static IEnumerable<SurveyDisplayResponse> ConvertSurveyToDisplayResponses(this IEnumerable<Survey> surveys, IMapper mapper)
        {
            return mapper.Map<IEnumerable<SurveyDisplayResponse>>(surveys);
        }

        public static IEnumerable<UserDisplayResponse> ConvertUserToDisplayResponses(this IEnumerable<User> users, IMapper mapper)
        {
            return mapper.Map<IEnumerable<UserDisplayResponse>>(users);
        }

        public static IEnumerable<SurveyResponseDisplayResponse> ConvertSurveyResponseToDisplayResponses(this IEnumerable<SurveyResponse> surveyResponses, IMapper mapper)
        {
            return mapper.Map<IEnumerable<SurveyResponseDisplayResponse>>(surveyResponses);
        }
    }
}
