using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using URAL.Domain.Entities;

namespace URAL.Infrastructure.Configurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasKey(m => m.Id);

        builder.HasOne(m => m.User)
            .WithMany(u => u.Messages)
            .HasForeignKey(m => m.UserId);
        
        builder.HasOne(m => m.Chat)
            .WithMany(c => c.Messages)
            .HasForeignKey(m => m.ChatId);
    }
}