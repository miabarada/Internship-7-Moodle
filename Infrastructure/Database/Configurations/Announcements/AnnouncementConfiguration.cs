using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Announcements
{
    internal sealed class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.ToTable("Announcement");

            builder.HasKey(a => a.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Title)
                .HasColumnName("Title")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Content)
                .HasColumnName("Content")
                .IsRequired()
                .HasMaxLength(5000);

            builder.Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired()
                .HasColumnType("timestamp without time zone");

            builder.Property(x => x.CourseId)
                .HasColumnName("CourseId")
                .IsRequired();

            builder.HasOne(c => c.Course)
                .WithMany(c => c.Announcements)
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.ProfessorId)
                .HasColumnName("ProfessorId")
                .IsRequired();

            builder.HasOne(c => c.Professor)
                .WithMany()
                .HasForeignKey(c => c.ProfessorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
