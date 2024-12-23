using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using URAL.Domain.Entities;

namespace URAL.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        builder.HasIndex(user => user.Email).IsUnique();
        builder.HasIndex(user => user.NormalizedEmail).IsUnique();
        builder.HasIndex(user => user.UserName).IsUnique(false);
        builder.HasIndex(user => user.NormalizedUserName).IsUnique(false);
        builder.HasIndex(user => user.PhoneNumber).IsUnique();
        
        builder.HasMany(user => user.Cars)
            .WithOne(cars => cars.User)
            .HasForeignKey(car => car.UserId);
        
        builder.HasMany(user => user.Cargo)
            .WithOne(cargo => cargo.User)
            .HasForeignKey(car => car.UserId);

        builder.HasMany(user => user.FirstNotifyCars)
            .WithOne(notify => notify.FirstUser)
            .HasForeignKey(notify => notify.FirstUserId);
        
        builder.HasMany(user => user.SecondNotifyCars)
            .WithOne(notify => notify.SecondUser)
            .HasForeignKey(notify => notify.SecondUserId);

        builder.HasMany(user => user.FirstNotifyCargo)
            .WithOne(notify => notify.FirstUser)
            .HasForeignKey(notify => notify.FirstUserId);
        
        builder.HasMany(user => user.SecondNotifyCargo)
            .WithOne(notify => notify.SecondUser)
            .HasForeignKey(notify => notify.SecondUserId);

        builder.HasMany(user => user.FirstChats)
            .WithOne(chat => chat.FirstUser)
            .HasForeignKey(chat => chat.FirstUserId);
        
        builder.HasMany(user => user.SecondChats)
            .WithOne(chat => chat.SecondUser)
            .HasForeignKey(chat => chat.SecondUserId);

        builder.HasMany(user => user.Messages)
            .WithOne(m => m.User)
            .HasForeignKey(m => m.UserId);
    }
}