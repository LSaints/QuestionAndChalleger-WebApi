using Microsoft.EntityFrameworkCore;
using QuestionAndChalleger.Domain.Entities;
using QuestionAndChalleger.Manager.Interfaces.Repository;

namespace QuestionAndChalleger.Data.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly QuestionAndChallegerContext _context;
        public QuestionRepository(QuestionAndChallegerContext context)
        {
            _context = context;
        }
        public async Task<Question> DeleteAsync(int id)
        {
            var questionFind = await _context.Questions.FindAsync(id);
            if (questionFind == null)
            {
                return null;
            }

            var questionForRemove = _context.Questions.Remove(questionFind);
            await _context.SaveChangesAsync();
            return questionForRemove.Entity;
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _context.Questions
                .AsNoTracking().ToListAsync();
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            return await _context.Questions.FindAsync(id);
        }

        public async Task<Question> InsertAsync(Question entity)
        {
            await _context.Questions.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Question> UpdateAsync(Question entity)
        {
            var entityFind = await _context.Questions.FindAsync(entity.Id);
            if (entityFind == null)
            {
                return null;
            }

            _context.Entry(entityFind).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return entityFind;
        }
    }
}
