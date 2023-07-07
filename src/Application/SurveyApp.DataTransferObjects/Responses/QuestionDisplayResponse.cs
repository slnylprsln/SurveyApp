using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Responses
{
    public class QuestionDisplayResponse
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int SurveyId { get; set; }
        public Category Category { get; set; }
        public List<string>? Options { get; set; }
    }
}
