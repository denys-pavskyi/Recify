using DAL.Entities;
using Microsoft.EntityFrameworkCore;

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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}