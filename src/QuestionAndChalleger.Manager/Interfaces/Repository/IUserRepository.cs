using QuestionAndChalleger.Domain.Entities;

namespace QuestionAndChalleger.Manager.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByLogin(string name, string password);

    }
}
