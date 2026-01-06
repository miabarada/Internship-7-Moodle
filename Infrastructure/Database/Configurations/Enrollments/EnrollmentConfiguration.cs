using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Enrollments
{
    internal sealed class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollment");

            builder.HasKey(e => new {e.StudentId, e.CourseId});
            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.StudentId)
                .HasColumnName("StudentId")
                .IsRequired();

            builder.HasOne(c => c.Student)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(c => c.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.CourseId)
                .HasColumnName("CourseId")
                .IsRequired();

            builder.HasOne(c => c.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
