using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using URAL.Domain.Entities;

namespace URAL.Infrastructure.Configurations;

public class ChatConfiguration : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder.HasKey(chat => chat.Id);
        
        builder.HasOne(chat => chat.FirstUser)
            .WithMany(user => user.FirstChats)
            .HasForeignKey(chat => chat.FirstUserId);

        builder.HasOne(chat => chat.SecondUser)
            .WithMany(user => user.SecondChats)
            .HasForeignKey(chat => chat.SecondUserId);

        builder.HasMany(chat => chat.Messages)
            .WithOne(m => m.Chat)
            .HasForeignKey(m => m.ChatId);

        builder.HasOne(chat => chat.NotifyCar)
            .WithMany(notify => notify.Chats)
            .HasForeignKey(chat => chat.NotifyCarId);

        builder.HasOne(chat => chat.NotifyCargo)
            .WithMany(notify => notify.Chats)
            .HasForeignKey(chat => chat.NotifyCargoId);
    }
}