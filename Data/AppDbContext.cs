using Microsoft.EntityFrameworkCore;
using aspnetegitim.Models;

namespace aspnetegitim.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<Message> Messages { get; set; } = null!;
    public DbSet<aspnetegitim.Models.Note> Notes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Project>(eb =>
        {
            eb.HasKey(p => p.Id);
            eb.Property(p => p.Name).IsRequired();
        });

        modelBuilder.Entity<Message>(eb =>
        {
            eb.HasKey(m => m.Id);
            eb.Property(m => m.FullName).IsRequired(false);
            eb.Property(m => m.BodyHtml).IsRequired(false);
        });

        modelBuilder.Entity<aspnetegitim.Models.Note>(eb =>
        {
            eb.HasKey(n => n.Id);
            eb.Property(n => n.Title).IsRequired(false);
            eb.Property(n => n.Body).IsRequired(false);
            eb.Property(n => n.CreatedAt).IsRequired();
        });
    }
}
