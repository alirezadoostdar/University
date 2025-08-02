using University.Domain.Entities;

namespace University.Domain.Interfaces;

public interface ISemesterRepository
{
    Semester? GetById(int id);
    List<Semester> GetAll();
    void Add(Semester semester);
    void Update(Semester semester);
    void Delete(Semester semester);
}
