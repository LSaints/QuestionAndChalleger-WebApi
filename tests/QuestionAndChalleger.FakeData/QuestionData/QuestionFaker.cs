using Bogus;
using QuestionAndChalleger.Domain.Entities;

namespace QuestionAndChalleger.FakeData.QuestionData
{
    public class QuestionFaker : Faker<Question>
    {
        public QuestionFaker()
        {
            var id = new Faker().Random.Number(1, 99999);
            RuleFor(p => p.Id, f => id);
            RuleFor(p => p.Description, f => f.Lorem.Text());
            RuleFor(p => p.Category, f => f.PickRandom<Category>());
            RuleFor(p => p.Level, f => f.PickRandom<Level>());
        }
    }
}
