using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        public string? Options { get; set; }

        public List<string>? GetOptions()
        {
            return JsonSerializer.Deserialize<List<string>>(Options);
        }

        public void SetOptions(List<string> options)
        {
            Options = JsonSerializer.Serialize(options);
        }
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
