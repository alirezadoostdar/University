using Microsoft.EntityFrameworkCore;
using University.Domain.Entities;

namespace Uninversity.Infarstructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Student> Students{ get; set; }
    public DbSet<Teacher> Teachers{ get; set; }
}
