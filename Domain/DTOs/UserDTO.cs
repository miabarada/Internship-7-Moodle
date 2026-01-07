using Domain.Enums;

namespace Domain.DTOs
{
    public class UserDTO
    {
        public int Id { get; init; }
        public string Email { get; set; } = null!;
        public string PasswordHush { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public Role Role { get; set; }
    }
}
