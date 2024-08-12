using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using URAL.Domain.Common;
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
    public DbSet<Chat>Chats { get; set; }
    public DbSet<Message>Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Cargo>().Property(e => e.Id).UseIdentityColumn();
        modelBuilder.Entity<Car>().Property(e => e.Id).UseIdentityColumn();
        modelBuilder.Entity<NotifyCargo>().Property(e => e.Id).UseIdentityColumn();
        modelBuilder.Entity<NotifyCar>().Property(e => e.Id).UseIdentityColumn();
        modelBuilder.Entity<BodyType>().Property(e => e.Id).UseIdentityColumn();
        modelBuilder.Entity<LoadingType>().Property(e => e.Id).UseIdentityColumn();
        modelBuilder.ApplyConfiguration(new BodyTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CarConfiguration());
        modelBuilder.ApplyConfiguration(new CargoConfiguration());
        modelBuilder.ApplyConfiguration(new LoadingTypeConfiguration());
        modelBuilder.ApplyConfiguration(new NotifyCarConfiguration());
        modelBuilder.ApplyConfiguration(new NotifyCargoConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ChatConfiguration());
    }
}