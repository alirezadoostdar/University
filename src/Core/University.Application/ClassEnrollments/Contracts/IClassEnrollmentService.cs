using University.Application.ClassEnrollments.Contracts.Dtos;

namespace University.Application.ClassEnrollments.Contracts;

public interface IClassEnrollmentService
{
    List<GetClassEnrollmentDto> GetAll();
    GetClassEnrollmentDto GetById(int id);
    void Add(AddClassEnrollmentDto dto);
    void Update(UpdateClassEnrollmentDto dto);
    void Delete(int id);
}
