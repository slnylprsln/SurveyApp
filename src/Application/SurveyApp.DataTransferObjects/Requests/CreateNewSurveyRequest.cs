using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Requests
{
    public class CreateNewSurveyRequest
    {
        public string? Title { get; set; }
        public int UserId { get; set; }
    }
}
