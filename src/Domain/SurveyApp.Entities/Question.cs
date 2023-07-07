using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Entities
{
    public class Question : IEntity
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
        public Category Category { get; set; }
        public List<string>? Options { get; set; }
    }

    public enum Category
    {
        // Tek satırlık düz metin
        SingleLineText,

        // Çok satırlı düz metin
        MultipleLineText,

        // Değerlendirme (1-10)
        Evaluation,

        // Çoktan seçmeli
        MultipleChoice
    }
}
