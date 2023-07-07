﻿using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Responses
{
    public class SurveyResponseDisplayResponse
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
    }
}
