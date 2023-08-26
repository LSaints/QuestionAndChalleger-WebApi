using QuestionAndChalleger.Domain.Entities;
using QuestionAndChalleger.Manager.Interfaces.Manager;
using QuestionAndChalleger.Manager.Interfaces.Repository;

namespace QuestionAndChalleger.Manager.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }


        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public Task<User> GetByIdAsync(int id)
        {
            return _userRepository.GetByIdAsync(id);
        }

        public Task<User> InsertAsync(User entity)
        {
            return _userRepository.InsertAsync(entity);
        }

        public Task<User> UpdateAsync(User entity)
        {
            return _userRepository.UpdateAsync(entity);
        }
    }
}
