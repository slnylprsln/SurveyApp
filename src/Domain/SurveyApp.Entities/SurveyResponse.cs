using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Entities
{
    public class SurveyResponse : IEntity
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public string Answer { get; set; }
    }
}
