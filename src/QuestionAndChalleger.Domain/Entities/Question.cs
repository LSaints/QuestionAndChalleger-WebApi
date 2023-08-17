using System.Text.Json.Serialization;

namespace QuestionAndChalleger.Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Category Category { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Level Level { get; set; }
    }
}
