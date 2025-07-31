using University.Domain.Entities;

namespace University.Domain.Interfaces;

public interface IStudentRepository
{
    Student? GetById(int id);
    List<Student> GetAll();
    void Add(Student student);
    void Update(Student student);
    void Delete(Student student);
}
