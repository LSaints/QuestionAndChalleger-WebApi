using QuestionAndChalleger.Domain.Entities;

namespace QuestionAndChalleger.Manager.Interfaces.Services
{
    public interface ITokenServices
    {
        string GenerateToken(User user);
    }
}
