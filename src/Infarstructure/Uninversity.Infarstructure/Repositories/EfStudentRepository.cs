using University.Domain.Entities;
using University.Domain.Interfaces;

namespace Uninversity.Infarstructure.Repositories;

public class EfStudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _context;

    public EfStudentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Student student)
    {
        _context.Students.Add(student);
    }

    public void Delete(Student student)
    {
        _context.Students.Remove(student);
    }

    public List<Student> GetAll()
    {
        return _context.Students.ToList();
    }

    public Student? GetById(int id)
    {
        return _context.Students.Find(id);
    }

    public void Update(Student student)
    {
        _context.Students.Update(student);
    }
}
