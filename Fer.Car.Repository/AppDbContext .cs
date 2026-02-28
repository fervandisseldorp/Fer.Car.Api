using Microsoft.EntityFrameworkCore;

namespace Fer.Car.Repository;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Entities.Car>()
            .Property(c => c.Id)
            .HasDefaultValueSql("gen_random_uuid()")
            .ValueGeneratedOnAdd();

        // Add unique constraint on LicensePlateNumber
        modelBuilder.Entity<Entities.Car>()
            .HasIndex(c => c.LicensePlateNumber)
            .IsUnique();
    }

    public DbSet<Entities.Car> Cars { get; set; }
}