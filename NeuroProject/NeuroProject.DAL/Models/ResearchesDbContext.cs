using Microsoft.EntityFrameworkCore;

namespace NeuroProject.DAL.Models;

public sealed class ResearchesDbContext : DbContext
{
    public DbSet<Research> Researches { get; set; }
    public DbSet<TestSubject> TestSubjects { get; set; }
    public DbSet<Record> Records { get; set; }

    public ResearchesDbContext(DbContextOptions<ResearchesDbContext> options)
        : base(options)
    { 
            
    }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // === Research ===
        modelBuilder.Entity<Research>(entity =>
        {
            entity.HasKey(r => r.Id); // PK
            entity.Property(r => r.Title).IsRequired();
        });

        // === TestSubject ===
        modelBuilder.Entity<TestSubject>(entity =>
        {
            entity.HasKey(ts => ts.Id); // PK

            entity.HasOne(ts => ts.Research) // FK
                .WithMany(r => r.TestSubjects)
                .HasForeignKey(ts => ts.ResearchId)
                .OnDelete(DeleteBehavior.Cascade); // или Restrict, если надо

            entity.Property(ts => ts.Name).IsRequired();
        });

        // === Record ===
        modelBuilder.Entity<Record>(entity =>
        {
            entity.HasKey(r => r.Id); // PK

            entity.HasOne(r => r.TestSubject) // FK
                .WithMany(ts => ts.Records)
                .HasForeignKey(r => r.TestSubjectId)
                .OnDelete(DeleteBehavior.Cascade); // или Restrict, если надо

            entity.Property(r => r.Hash).IsRequired();
        });
    }

}