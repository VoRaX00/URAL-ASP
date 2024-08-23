using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using URAL.Domain.Entities;

namespace URAL.Infrastructure.Configurations;

public class NotifyCarConfiguration : IEntityTypeConfiguration<NotifyCar>
{
    public void Configure(EntityTypeBuilder<NotifyCar> builder)
    {
        builder.HasKey(notify => notify.Id);

        builder.HasOne(notify => notify.Car)
            .WithMany(car => car.NotifyCars);
        
        builder.HasOne(notify => notify.FirstUser)
            .WithMany(user => user.FirstNotifyCars)
            .HasForeignKey(notify => notify.FirstUserId);

        builder.HasOne(notify => notify.SecondUser)
            .WithMany(user => user.SecondNotifyCars)
            .HasForeignKey(notify => notify.SecondUserId);

        builder.HasMany(notify => notify.Chats)
            .WithOne(chat => chat.NotifyCar)
            .HasForeignKey(chat => chat.NotifyCarId);
    }
}