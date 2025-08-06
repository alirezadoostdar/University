using University.Application.ClassEnrollments.Contracts.Dtos;

namespace University.Application.ClassEnrollments.Contracts;

public interface IClassEnrollmentService
{
    void Add(AddClassEnrollmentDto dto);
    void Delete(DeleteClassEnrollmentDto dto);
}
