using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using URAL.Domain.Entities;

namespace URAL.Infrastructure.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(car => car.Id);

        builder.HasOne(car => car.User)
            .WithMany(user => user.Cars)
            .HasForeignKey(car => car.UserId);
        
        builder.HasMany(car => car.BodyTypes)
            .WithMany(body => body.Cars);
        
        builder.HasMany(car => car.LoadingTypes)
            .WithMany(loading => loading.Cars);
        
        builder.HasMany(car => car.NotifyCars)
            .WithOne(notify => notify.Car)
            .HasForeignKey(notify => notify.CarId);
    }
}