using Domain.Entities;
using Domain.Persistence.Users;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Users
{
    internal sealed class UserRepository : Repository<User, int>, IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async void Add(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> Exists(string Email)
        {
            return _dbContext.Users.AnyAsync(u => u.Email == Email);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email.ToUpper() == email.ToUpper());
        }

        public async Task<User?> GetById(int id)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetProfessors()
        {
            return await _dbContext.Users
                .Where(u => u.Role == Domain.Enums.Role.Profesor)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetStudents()
        {
            return await _dbContext.Users
                .Where(u => u.Role == Domain.Enums.Role.Student)
                .ToListAsync();
        }

        public void Remove(User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChangesAsync();
        }
    }
}
