using Microsoft.EntityFrameworkCore;

namespace NeuroProject.DAL.Models;

public sealed class ResearchesDbContext : DbContext
{
    public DbSet<Research> Researches { get; set; }
    public DbSet<Record> Records { get; set; }
    public DbSet<TestSubject> TestSubjects { get; set; }


    public ResearchesDbContext(DbContextOptions<ResearchesDbContext> options)
        : base(options)
    { 
            
    }
        
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Research>()
    //         .HasMany(x => x.Versions)
    //         .WithOne(x => x.Material)
    //         .HasForeignKey(x => x.MaterialId);
    // }
}