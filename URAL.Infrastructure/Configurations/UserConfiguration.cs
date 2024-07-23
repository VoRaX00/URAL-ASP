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
    }
}