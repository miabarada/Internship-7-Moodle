using Domain.Entities;
using Domain.Persistence.Common;

namespace Domain.Persistence.Users
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<User?> GetById(int id);
        Task<User?> GetByEmail(string email);

        Task<IEnumerable<User>> GetAll();
        Task<IEnumerable<User>> GetStudents();
        Task<IEnumerable<User>> GetProfessors();

        void Add(User user);
        void Update(User user);
        void Remove(User user);
    }
}
