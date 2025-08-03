using University.Domain.Entities;

namespace University.Domain.Interfaces;

public interface IClassEnrollmentRepository
{
    List<ClassEnrollment> GetAll();
    ClassEnrollment? GetById(int id);
    void Add(ClassEnrollment classEnrollment);
    void Update(ClassEnrollment classEnrollment);
    void Delete(ClassEnrollment classEnrollment);
}
