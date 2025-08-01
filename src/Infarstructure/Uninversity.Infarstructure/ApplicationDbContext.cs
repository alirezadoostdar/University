using Microsoft.EntityFrameworkCore;
using University.Domain.Entities;

namespace Uninversity.Infarstructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly );
    }

    public DbSet<Student> Students{ get; set; }
    public DbSet<Teacher> Teachers{ get; set; }
}
