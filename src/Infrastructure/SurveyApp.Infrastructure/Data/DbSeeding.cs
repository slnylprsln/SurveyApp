using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Infrastructure.Data
{
    public class DbSeeding
    {
        public static void SeedDatabase(SurveyDbContext context)
        {
            seedUserIfNotExists(context);
            seedSurveyIfNotExists(context);
            seedQuestionIfNotExists(context);
            seedSurveyResponseIfNotExists(context);
        }

        public static void seedUserIfNotExists(SurveyDbContext context)
        {
            if (!context.Users.Any())
            {
                var users = new List<User>() {
                    new() { Name = "Selenay Alparslan", Email = "test1@gmail.com", Password = "1234Abcd!", Role = Role.Admin, UserName = "selenaya" },
                    new() { Name = "Taylor Swift", Email = "test2@gmail.com", Password = "1234Abcd!", Role = Role.Member, UserName = "taylors" },
                    new() { Name = "Louis Tomlinson", Email = "test3@gmail.com", Password = "1234Abcd!", Role = Role.Member, UserName = "louist" }
                };

                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }

        public static void seedSurveyIfNotExists(SurveyDbContext context)
        {
            if (!context.Surveys.Any())
            {
                var surveys = new List<Survey>() {
                    new() { Title = "Memnuniyet Anketi", CreationDate = DateTime.Now, UserId = 1 },
                    new() { Title = "Deneme Anketi", CreationDate = DateTime.Now, UserId = 2 }
                };

                context.Surveys.AddRange(surveys);
                context.SaveChanges();
            }
        }

        public static void seedQuestionIfNotExists(SurveyDbContext context)
        {
            if (!context.Questions.Any())
            {
                var questions = new List<Question>() {
                    new() { Content = "Uygulamamızla ilgili şikayetleriniz nelerdir?", Category = Category.MultipleLineText, SurveyId = 1 },
                    new() { Content = "Uygulamamıza önerileriniz nelerdir?", Category = Category.MultipleLineText, SurveyId = 1 },
                    new() { Content = "Uygulamamızı 1 ve 10 arasında puanlayınız.", Category = Category.Evaluation, SurveyId = 1 },
                    new() { Content = "Uygulamamızı arkadaşlarınıza önerir misiniz?", Category = Category.SingleLineText, SurveyId = 1 },
                };

                var q = new Question()
                {
                    Content = "Uygulamamızdan nasıl haberdar oldunuz?",
                    Category = Category.MultipleChoice,
                    SurveyId = 1
                };
                var options = new List<string>() { "Arkadaş/Tanıdık", "Televizyon", "Sosyal Medya", "Billboard" };
                q.SetOptions(options);
                questions.Add(q);

                context.Questions.AddRange(questions);
                context.SaveChanges();
            }
        }

        public static void seedSurveyResponseIfNotExists(SurveyDbContext context)
        {
            if (!context.SurveyResponses.Any())
            {
                var surveyResponses = new List<SurveyResponse>() {
                    new() { SurveyId = 1, QuestionId = 1, Answer = "Uygulamanızın arayüzü çok karışık ve kullanıcı dostu değil. Menüler ve sekmeler anlaşılması zor ve gezinmek zaman alıyor. Ayrıca, uygulama çok yavaş çalışıyor ve sık sık donuyor. Bu da kullanıcı deneyimini olumsuz etkiliyor." },
                    new() { SurveyId = 1, QuestionId = 2, Answer = "Uygulamaya daha fazla kullanıcı geri bildirimi almak için anketler veya geri bildirim formları gibi araçlar ekleyin." },
                    new() { SurveyId = 1, QuestionId = 3, Answer = "7" },
                    new() { SurveyId = 1, QuestionId = 4, Answer = "Evet öneririm" },
                    new() { SurveyId = 1, QuestionId = 5, Answer = "Sosyal Medya, Televizyon" }
                };

                context.SurveyResponses.AddRange(surveyResponses);
                context.SaveChanges();
            }
        }
    }
}
