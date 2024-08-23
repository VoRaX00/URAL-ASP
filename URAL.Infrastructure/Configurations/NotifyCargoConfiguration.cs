using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using URAL.Domain.Entities;

namespace URAL.Infrastructure.Configurations;

public class NotifyCargoConfiguration : IEntityTypeConfiguration<NotifyCargo>
{
    public void Configure(EntityTypeBuilder<NotifyCargo> builder)
    {
        builder.HasKey(notify => notify.Id);
        
        builder.HasOne(notify => notify.Cargo)
            .WithMany(cargo => cargo.NotifyCargo)
            .HasForeignKey(notify => notify.CargoId);

        builder.HasOne(notify => notify.FirstUser)
            .WithMany(user => user.FirstNotifyCargo)
            .HasForeignKey(notify => notify.FirstUserId);

        builder.HasOne(notify => notify.SecondUser)
            .WithMany(user => user.SecondNotifyCargo)
            .HasForeignKey(notify => notify.SecondUserId);
        
        builder.HasMany(notify => notify.Chats)
            .WithOne(chat => chat.NotifyCargo)
            .HasForeignKey(chat => chat.NotifyCargoId);
    }
}