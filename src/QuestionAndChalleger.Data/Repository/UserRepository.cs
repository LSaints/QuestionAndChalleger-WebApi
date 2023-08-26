using Microsoft.EntityFrameworkCore;
using QuestionAndChalleger.Domain.Entities;
using QuestionAndChalleger.Manager.Interfaces.Repository;

namespace QuestionAndChalleger.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly QuestionAndChallegerContext _context;
        public UserRepository(QuestionAndChallegerContext context)
        {
            _context = context;
        }

        public async Task<User> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            var userForRemove = _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return userForRemove.Entity;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                 .AsNoTracking().ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users
                .AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<User> InsertAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<User> UpdateAsync(User entity)
        {
            var entityFind = await _context.Users.FindAsync(entity.Id);
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
