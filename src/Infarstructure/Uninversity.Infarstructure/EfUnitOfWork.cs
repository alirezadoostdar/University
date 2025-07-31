using University.Application;

namespace Uninversity.Infarstructure;

public class EfUnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public EfUnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Begin()
    {
        _context.Database.BeginTransaction();
    }

    public void Commit()
    {
        _context.Database.CommitTransaction();
    }

    public void Rollback()
    {
        _context.Database.RollbackTransaction();
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
