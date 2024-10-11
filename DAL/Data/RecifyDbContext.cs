using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DAL.Data;

public class RecifyDbContext: DbContext
{
    public RecifyDbContext(DbContextOptions<RecifyDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<LinkedDatabase> LinkedDatabases { get; set; }
    public DbSet<UploadedCSV> UploadedCSVs { get; set; }
    public DbSet<RecommenderConfiguration> RecommenderConfigurations { get; set; }
    public DbSet<RecommenderToUploadedCSVs> RecommenderToUploadedCSVs { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<RecommenderToUploadedCSVs>()
            .HasOne(r => r.RecommenderConfiguration)
            .WithMany(rc => rc.RecommenderToUploadedCSVs)
            .HasForeignKey(r => r.ConfigurationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<RecommenderToUploadedCSVs>()
            .HasOne(r => r.UploadedCsv)
            .WithMany(u => u.RecommenderToUploadedCSVs)
            .HasForeignKey(r => r.UploadedCsvId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}