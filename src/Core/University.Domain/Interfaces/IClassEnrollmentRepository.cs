using University.Domain.Entities;

namespace University.Domain.Interfaces;

public interface IClassEnrollmentRepository
{
    List<ClassEnrollment> GetAll();
    void Add(ClassEnrollment classEnrollment);
    void Delete(ClassEnrollment classEnrollment);
}
