using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using URAL.Domain.Entities;
using URAL.Infrastructure.Configurations;

namespace URAL.Infrastructure.Context;

public class UralDbContext(DbContextOptions<UralDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<BodyType> BodyTypes { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Cargo> Cargo { get; set; }
    public DbSet<LoadingType> LoadingTypes { get; set; }
    public DbSet<NotifyCar> NotifyCars { get; set; }
    public DbSet<NotifyCargo> NotifyCargo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BodyTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CarConfiguration());
        modelBuilder.ApplyConfiguration(new CargoConfiguration());
        modelBuilder.ApplyConfiguration(new LoadingTypeConfiguration());
        modelBuilder.ApplyConfiguration(new NotifyCarConfiguration());
        modelBuilder.ApplyConfiguration(new NotifyCargoConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}