using University.Domain.Entities;
using University.Domain.Interfaces;

namespace Uninversity.Infarstructure.Repositories;

public class EfClassEnrollmentRepository : IClassEnrollmentRepository
{
    private readonly ApplicationDbContext _context;

    public EfClassEnrollmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(ClassEnrollment classEnrollment)
    {
        _context.ClassEnrollments.Add(classEnrollment);
    }

    public void Delete(ClassEnrollment classEnrollment)
    {
        _context.ClassEnrollments.Remove(classEnrollment);
    }

    public List<ClassEnrollment> GetAll()
    {
        return _context.ClassEnrollments.ToList();
    }

    public ClassEnrollment? GetById(int id)
    {
        return _context.ClassEnrollments.Find(id);
    }

    public void Update(ClassEnrollment classEnrollment)
    {
        _context.ClassEnrollments.Update(classEnrollment);
    }
}
