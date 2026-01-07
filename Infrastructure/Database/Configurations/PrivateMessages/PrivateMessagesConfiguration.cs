
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.PrivateMessages
{
    internal sealed class PrivateMessagesConfiguration : IEntityTypeConfiguration<PrivateMessage>
    {
        public void Configure(EntityTypeBuilder<PrivateMessage> builder)
        {
            builder.ToTable("PrivateMessage");

            builder.HasKey(p => p.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.SenderId)
                .HasColumnName("SenderId")
                .IsRequired();

            builder.HasOne(c => c.Sender)
                .WithMany(c => c.SentMessages)
                .HasForeignKey(c => c.SenderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.ReceiverId)
                .HasColumnName("ReceiverId")
                .IsRequired();

            builder.HasOne(c => c.Receiver)
                .WithMany(c => c.ReceivedMessages)
                .HasForeignKey(c => c.ReceiverId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Content)
                .HasColumnName("Content")
                .IsRequired()
                .HasMaxLength(5000);

            builder.Property(x => x.SentAt)
                .HasColumnName("SentAt")
                .IsRequired()
                .HasColumnType("timestamp without time zone");
        }
    }
}
