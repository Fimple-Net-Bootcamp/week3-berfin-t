using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetCareApplication.Data;

    public class PetCareDbContext : DbContext
    {
        public PetCareDbContext(DbContextOptions<PetCareDbContext> options) : base(options)
        {
        }

        public DbSet<Activities> Activities { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<HealthCondition> HealthCondition { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Pets)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);

        

        base.OnModelCreating(modelBuilder);
    }


}

