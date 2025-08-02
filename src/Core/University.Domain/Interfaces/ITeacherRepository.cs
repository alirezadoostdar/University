using University.Domain.Entities;

namespace University.Domain.Interfaces;

public interface ITeacherRepository
{
    Teacher? GetById(int id);
    List<Teacher> GetAll();
    void Add(Teacher teacher);
    void Update(Teacher teacher);
    void Delete(Teacher teacher);
}
