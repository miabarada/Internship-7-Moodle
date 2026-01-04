using Domain.Common.Model;
using Domain.Common.Validation.ValidationItems;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public String Email { get; set; } = null!;
        public String Password { get; set; } = null!;

        public String Name { get; set; } = null!;
        public String Surname { get; set; } = null!;

        public Role Role { get; set; }

        public ICollection<PrivateMessage> SentMessages { get; set; } = new List<PrivateMessage>();
        public ICollection<PrivateMessage> RecievedMessages { get; set; } = new List<PrivateMessage>();
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
