using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Users
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.PasswordHash)
                .HasColumnName("PasswordHash")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(100);

            builder.Property(x => x.Surname)
                .HasColumnName("Surname")
                .HasMaxLength(100);

            builder.Property(x => x.Role)
                .HasColumnName("Role")
                .HasConversion<string>()
                .IsRequired();
        }
    }
}
