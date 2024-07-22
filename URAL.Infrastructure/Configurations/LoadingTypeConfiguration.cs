using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using URAL.Domain.Entities;

namespace URAL.Infrastructure.Configurations;

public class LoadingTypeConfiguration : IEntityTypeConfiguration<LoadingType>
{
    public void Configure(EntityTypeBuilder<LoadingType> builder)
    {
        builder.HasKey(loading => loading.Id);
        
        builder.HasMany(loading => loading.Cars)
            .WithMany(car => car.LoadingTypes);
    }
}