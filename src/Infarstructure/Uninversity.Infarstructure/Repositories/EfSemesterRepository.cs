using University.Domain.Entities;
using University.Domain.Interfaces;

namespace Uninversity.Infarstructure.Repositories;

public class EfSemesterRepository : ISemesterRepository
{
    private readonly ApplicationDbContext _context;

    public EfSemesterRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Semester semester)
    {
        _context.Semesters.Add(semester);
    }

    public void Delete(Semester semester)
    {
        _context.Semesters.Remove(semester);
    }

    public List<Semester> GetAll()
    {
        return _context.Semesters.ToList();
    }

    public Semester? GetById(int id)
    {
        return _context.Semesters.Find(id);
    }

    public void Update(Semester semester)
    {
        _context.Semesters.Update(semester);
    }
}
