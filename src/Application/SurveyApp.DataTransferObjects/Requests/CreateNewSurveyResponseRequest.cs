using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Requests
{
    public class CreateNewSurveyResponseRequest
    {
        public int SurveyId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
    }
}
