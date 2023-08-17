using QuestionAndChalleger.Domain.Entities;
using QuestionAndChalleger.Manager.Interfaces.Manager;
using QuestionAndChalleger.Manager.Interfaces.Repository;

namespace QuestionAndChalleger.Manager.Implementation
{
    public class QuestionManager : IQuestionManager
    {
        private readonly IQuestionRepository _repository;
        public QuestionManager(IQuestionRepository repository)
        {
            _repository = repository;
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Question> InsertAsync(Question entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task<Question> UpdateAsync(Question entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
