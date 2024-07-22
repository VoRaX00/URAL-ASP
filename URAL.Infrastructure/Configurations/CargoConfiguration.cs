using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using URAL.Domain.Entities;

namespace URAL.Infrastructure.Configurations;

public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
{
    public void Configure(EntityTypeBuilder<Cargo> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder.HasOne(cargo => cargo.User)
            .WithMany(user => user.Cargo)
            .HasForeignKey(cargo => cargo.UserId);
        
        builder.HasMany(cargo => cargo.NotifyCargo)
            .WithOne(notify => notify.Cargo)
            .HasForeignKey(notify => notify.CargoId);
    }
}