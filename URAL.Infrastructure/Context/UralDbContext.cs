using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using URAL.Domain.Common;
using URAL.Domain.Entities;
using URAL.Infrastructure.Configurations;

namespace URAL.Infrastructure.Context;

public class UralDbContext : IdentityDbContext<User>
{
    public virtual DbSet<BodyType> BodyTypes { get; set; }
    public virtual DbSet<Car> Cars { get; set; }
    public virtual DbSet<Cargo> Cargo { get; set; }
    public virtual DbSet<LoadingType> LoadingTypes { get; set; }
    public virtual DbSet<NotifyCar> NotifyCars { get; set; }
    public virtual DbSet<NotifyCargo> NotifyCargo { get; set; }
    public virtual DbSet<Chat>Chats { get; set; }
    public virtual DbSet<Message>Messages { get; set; }
    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public UralDbContext()
    {
    }

    public UralDbContext(DbContextOptions<UralDbContext> options) : base(options)
    {
    }

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
        modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
    }
}