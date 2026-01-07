using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class AnnouncementDTO
    {
        public int Id { get; init; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CourseId { get; init; }
        public int ProfesorId { get; init; }
    }
}
