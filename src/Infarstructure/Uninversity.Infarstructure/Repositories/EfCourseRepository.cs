using University.Domain.Entities;
using University.Domain.Interfaces;

namespace Uninversity.Infarstructure.Repositories;

public class EfCourseRepository : ICourseRepository
{
    private readonly ApplicationDbContext _context;

    public EfCourseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Course course)
    {
        _context.Courses.Add(course);
    }

    public void Delete(Course course)
    {
        _context.Courses.Remove(course);
    }

    public List<Course> GetAll()
    {
        return _context.Courses.ToList();
    }

    public Course? GetById(int id)
    {
        return _context.Courses.Find(id);
    }

    public void Update(Course course)
    {
        _context.Courses.Update(course);
    }
}
