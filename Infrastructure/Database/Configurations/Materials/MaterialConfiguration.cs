using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Configurations.Materials
{
    internal class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Material> builder)
        {
            builder.ToTable("Material");

            builder.HasKey(a => a.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Url)
                .HasColumnName("Url")
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
                .WithMany(c => c.Materials)
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
