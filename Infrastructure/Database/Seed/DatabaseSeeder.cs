using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Seed
{
    public static class DatabaseSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Email = "mia.barada@gmail.com",
                    PasswordHash = "12345678",
                    Name = "Mia",
                    Surname = "Barada",
                    Role = Domain.Enums.Role.Admin
                },
                new User
                {
                    Id = 2,
                    Email = "andrea.barada@gmail.com",
                    PasswordHash = "87654321",
                    Name = "Andrea",
                    Surname = "Barada",
                    Role = Domain.Enums.Role.Student
                },
                new User
                {
                    Id = 3,
                    Email = "sara.cigler@gmail.com",
                    PasswordHash = "11223344",
                    Name = "Sara",
                    Surname = "Cigler",
                    Role = Domain.Enums.Role.Student
                },
                new User
                {
                    Id = 4,
                    Email = "daria.pazanin@gmail.com",
                    PasswordHash = "44332211",
                    Name = "Daria",
                    Surname = "Pazanin",
                    Role = Domain.Enums.Role.Student
                },
                new User
                {
                    Id = 5,
                    Email = "ana.bartulovic@gmail.com",
                    PasswordHash = "12121212",
                    Name = "Ana",
                    Surname = "Bartulovic",
                    Role = Domain.Enums.Role.Student
                },
                new User
                {
                    Id = 6,
                    Email = "lea.zebic@gmail.com",
                    PasswordHash = "34343434",
                    Name = "Lea",
                    Surname = "Zebic",
                    Role = Domain.Enums.Role.Student
                },
                new User
                {
                    Id = 7,
                    Email = "mia.milun@gmail.com",
                    PasswordHash = "13131313",
                    Name = "Mia",
                    Surname = "Milun",
                    Role = Domain.Enums.Role.Profesor
                },
                new User
                {
                    Id = 8,
                    Email = "maja.milanovic@gmail.com",
                    PasswordHash = "14141414",
                    Name = "Maja",
                    Surname = "Milanovic",
                    Role = Domain.Enums.Role.Profesor
                },
                new User
                {
                    Id = 9,
                    Email = "tomislav.buric@gmail.com",
                    PasswordHash = "232323",
                    Name = "Tomislav",
                    Surname = "Buric",
                    Role = Domain.Enums.Role.Profesor
                },
                new User
                {
                    Id = 10,
                    Email = "predrag.pale@gmail.com",
                    PasswordHash = "24242424",
                    Name = "Predrag",
                    Surname = "Pale",
                    Role = Domain.Enums.Role.Profesor
                },
                new User
                {
                    Id = 11,
                    Email = "ines.kezic@gmail.com",
                    PasswordHash = "32323232",
                    Name = "Ines",
                    Surname = "Kezic",
                    Role = Domain.Enums.Role.Profesor
                }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Matematika", ProfessorId = 7 },
                new Course { Id = 2, Name = "Hrvatski jezik", ProfessorId = 8 },
                new Course { Id = 3, Name = "Matematička analiza 2", ProfessorId = 9 },
                new Course { Id = 4, Name = "Vještine komuniciranja", ProfessorId = 10 },
                new Course { Id = 5, Name = "Glazbena kultura", ProfessorId = 11 }
            );

            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { Id = 1, StudentId = 2, CourseId = 1 },
                new Enrollment { Id = 2, StudentId = 3, CourseId = 1 },
                new Enrollment { Id = 3, StudentId = 4, CourseId = 2 },
                new Enrollment { Id = 4, StudentId = 5, CourseId = 2 },
                new Enrollment { Id = 5, StudentId = 6, CourseId = 3 },
                new Enrollment { Id = 6, StudentId = 2, CourseId = 3 },
                new Enrollment { Id = 7, StudentId = 3, CourseId = 4 },
                new Enrollment { Id = 8, StudentId = 4, CourseId = 5 }
            );

            modelBuilder.Entity<Announcement>().HasData(
                new Announcement
                {
                    Id = 1,
                    Title = "Dobrodošli",
                    Content = "Dobrodošli na kolegij Matan2",
                    CreatedAt = new DateTime(2024, 10, 1),
                    CourseId = 3,
                    ProfessorId = 9
                },
                new Announcement
                {
                    Id = 2,
                    Title = "Kolokvij",
                    Content = "Prvi kolokvij održat će se sljedeći tjedan.",
                    CreatedAt = new DateTime(2024, 10, 5),
                    CourseId = 2,
                    ProfessorId = 8
                },
                new Announcement
                {
                    Id = 3,
                    Title = "Zadaća",
                    Content = "Objavljena je prva zadaća.",
                    CreatedAt = new DateTime(2024, 10, 7),
                    CourseId = 3,
                    ProfessorId = 9
                },
                new Announcement
                {
                    Id = 4,
                    Title = "Predavanje",
                    Content = "Sljedeće predavanje je online.",
                    CreatedAt = new DateTime(2024, 10, 9),
                    CourseId = 4,
                    ProfessorId = 10
                },
                new Announcement
                {
                    Id = 5,
                    Title = "Materijali",
                    Content = "Dodani su novi materijali.",
                    CreatedAt = new DateTime(2024, 10, 12),
                    CourseId = 5,
                    ProfessorId = 11
                }
            );

            modelBuilder.Entity<Material>().HasData(
                new Material
                {
                    Id = 1,
                    Name = "Algebarski izrazi",
                    Url = "https://example.com/algebarskiizrazi",
                    CreatedAt = new DateTime(2024, 10, 2),
                    CourseId = 1,
                    ProfessorId = 7
                },
                new Material
                {
                    Id = 2,
                    Name = "Lovac u zitu",
                    Url = "https://example.com/lovacuzitu",
                    CreatedAt = new DateTime(2024, 10, 4),
                    CourseId = 2,
                    ProfessorId = 8
                },
                new Material
                {
                    Id = 3,
                    Name = "Diferencijalne jednadzbe",
                    Url = "https://example.com/difjedn",
                    CreatedAt = new DateTime(2024, 10, 6),
                    CourseId = 3,
                    ProfessorId = 9
                },
                new Material
                {
                    Id = 4,
                    Name = "Kako komunicirati",
                    Url = "https://example.com/komuniciranje",
                    CreatedAt = new DateTime(2024, 10, 8),
                    CourseId = 4,
                    ProfessorId = 10
                },
                new Material
                {
                    Id = 5,
                    Name = "Klasicizam",
                    Url = "https://example.com/klasicizam",
                    CreatedAt = new DateTime(2024, 10, 10),
                    CourseId = 5,
                    ProfessorId = 11
                }
            );

            modelBuilder.Entity<PrivateMessage>().HasData(
                new PrivateMessage { Id = 1, SenderId = 2, ReceiverId = 7, Content = "Profesorice, imam pitanje.", SentAt = new DateTime(2024, 10, 1) },
                new PrivateMessage { Id = 2, SenderId = 7, ReceiverId = 2, Content = "Naravno, pitaj.", SentAt = new DateTime(2024, 10, 1, 10, 0, 0) },

                new PrivateMessage { Id = 3, SenderId = 3, ReceiverId = 8, Content = "Kad je kolokvij", SentAt = new DateTime(2024, 10, 2) },
                new PrivateMessage { Id = 4, SenderId = 8, ReceiverId = 3, Content = "Sljedeći tjedan.", SentAt = new DateTime(2024, 10, 2, 11, 0, 0) },

                new PrivateMessage { Id = 5, SenderId = 4, ReceiverId = 9, Content = "Domaći mi nije jasnan", SentAt = new DateTime(2024, 10, 3) },
                new PrivateMessage { Id = 6, SenderId = 9, ReceiverId = 4, Content = "Objasnit ću na predavanju.", SentAt = new DateTime(2024, 10, 3, 9, 30, 0) },

                new PrivateMessage { Id = 7, SenderId = 5, ReceiverId = 10, Content = "Ima li dodatnih bodova?", SentAt = new DateTime(2024, 10, 4) },
                new PrivateMessage { Id = 8, SenderId = 10, ReceiverId = 5, Content = "Vidit ćemo.", SentAt = new DateTime(2024, 10, 4, 14, 0, 0) },

                new PrivateMessage { Id = 9, SenderId = 6, ReceiverId = 11, Content = "Imam problema s materijalima.", SentAt = new DateTime(2024, 10, 5) },
                new PrivateMessage { Id = 10, SenderId = 11, ReceiverId = 6, Content = "Pošalji screen.", SentAt = new DateTime(2024, 10, 5, 16, 0, 0) }
            );

        }
    }
}
