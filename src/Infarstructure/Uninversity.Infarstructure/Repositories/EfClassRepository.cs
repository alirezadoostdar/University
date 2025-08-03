using University.Domain.Entities;
using University.Domain.Interfaces;

namespace Uninversity.Infarstructure.Repositories;

public class EfClassRepository : IClassRepository
{
    private readonly ApplicationDbContext _context;

    public EfClassRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Class entity)
    {
        _context.Classes.Add(entity);
    }

    public void Delete(Class entity)
    {
        _context.Classes.Remove(entity);
    }

    public List<Class> GetAll()
    {
        return _context.Classes.ToList();
    }

    public Class? GetById(int id)
    {
        return _context.Classes.Find(id);
    }

    public void Update(Class entity)
    {
        _context.Classes.Update(entity);
    }
}
