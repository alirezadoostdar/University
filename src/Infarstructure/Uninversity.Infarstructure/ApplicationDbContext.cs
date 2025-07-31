using Microsoft.EntityFrameworkCore;

namespace Uninversity.Infarstructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

}
