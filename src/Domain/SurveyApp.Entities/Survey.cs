using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Entities
{
    public class Survey : IEntity
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Question>? Questions { get; set; }
    }
}
