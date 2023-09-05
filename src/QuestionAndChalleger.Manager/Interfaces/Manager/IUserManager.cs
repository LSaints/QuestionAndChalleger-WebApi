using QuestionAndChalleger.Domain.Entities;

namespace QuestionAndChalleger.Manager.Interfaces.Manager
{
    public interface IUserManager : IManager<User>
    {
        Task<User> GetByLogin(string name, string password);
    }
}
