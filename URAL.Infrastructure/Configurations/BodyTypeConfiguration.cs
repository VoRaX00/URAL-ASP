using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using URAL.Domain.Entities;

namespace URAL.Infrastructure.Configurations;

public class BodyTypeConfiguration  : IEntityTypeConfiguration<BodyType>
{
    public void Configure(EntityTypeBuilder<BodyType> builder)
    {
        builder.HasKey(body => body.Id);
        
        builder.HasMany(body => body.Cars)
            .WithMany(car => car.BodyTypes);
    }
}