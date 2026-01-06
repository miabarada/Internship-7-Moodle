using Domain.Persistence.Announcements;
using Domain.Persistence.Common;
using Domain.Persistence.Courses;
using Domain.Persistence.Materials;
using Domain.Persistence.PrivateMessages;
using Domain.Persistence.Users;
using Infrastructure.Database;
using Infrastructure.Repositories.Announcements;
using Infrastructure.Repositories.Courses;
using Infrastructure.Repositories.Materials;
using Infrastructure.Repositories.PrivateMessages;
using Infrastructure.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            AddDatabase(services, configuration);
            AddRepositories(services);

            return services;
        }

        private static void AddDatabase(IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("Database");
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IPrivateMessageRepository, PrivateMessageRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    } 
}
