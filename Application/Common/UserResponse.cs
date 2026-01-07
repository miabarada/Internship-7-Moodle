using Domain.Enums;

namespace Application.Common
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public Role Role { get; set; }
    }
}
