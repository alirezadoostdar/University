using University.Domain.Entities;
using University.Domain.Interfaces;

namespace Uninversity.Infarstructure.Repositories;

public class EfTeacherRepository : ITeacherRepository
{
    private readonly ApplicationDbContext _context;

    public EfTeacherRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Teacher teacher)
    {
        _context.Teachers.Add(teacher);
    }

    public void Delete(Teacher teacher)
    {
        _context.Teachers.Remove(teacher);
    }

    public List<Teacher> GetAll()
    {
        return _context.Teachers.ToList();
    }

    public Teacher? GetById(int id)
    {
        return _context.Teachers.Find(id);
    }

    public void Update(Teacher teacher)
    {
        _context.Teachers.Update(teacher);
    }
}
