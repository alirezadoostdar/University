using University.Domain.Entities;

namespace University.Domain.Interfaces;

public interface IStudentRepository
{
    Student GetById(int id);
    List<Student> GetAll();
    int Add(Student student);
    void Update(Student student);
    void Delete(int id);
}
