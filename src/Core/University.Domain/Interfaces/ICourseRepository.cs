using University.Domain.Entities;

namespace University.Domain.Interfaces;

public interface ICourseRepository
{
    List<Course> GetAll();
    Course? GetById(int id);
    void Add(Course course);
    void Update(Course course);
    void Delete(Course course);
}
